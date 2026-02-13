import argparse
import asyncio
import logging
import os
import shutil
import subprocess
import sys
from pathlib import Path
from typing import Sequence
from uuid import uuid4

import boto3
from botocore.exceptions import ClientError

LOGGER = logging.getLogger("payeredi.s3service")


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description="Read EDI files from S3 (moto-compatible) and process them asynchronously."
    )
    parser.add_argument(
        "--endpoint-url",
        default=os.environ.get("PAYEREDI_S3_ENDPOINT", "http://127.0.0.1:5000"),
        help="S3 endpoint URL.",
    )
    parser.add_argument("--region", default="us-east-1", help="AWS region.")
    parser.add_argument(
        "--bucket",
        default=os.environ.get("PAYEREDI_S3_BUCKET", "payeredi-edi"),
        help="Source S3 bucket.",
    )
    parser.add_argument(
        "--prefix",
        default=os.environ.get("PAYEREDI_S3_PREFIX", ""),
        help="Optional S3 key prefix.",
    )
    parser.add_argument("--suffix", default=".edi", help="Only process keys that end with this suffix.")
    parser.add_argument(
        "--command",
        nargs="+",
        default=None,
        help="Optional command prefix for processing each file. The local file path is appended as the last argument.",
    )
    parser.add_argument(
        "--working-dir",
        default=str(Path(__file__).resolve().parents[1]),
        help="Working directory for the ingestion command.",
    )
    parser.add_argument(
        "--temp-dir",
        default=str(Path(__file__).resolve().parent / ".runtime-temp"),
        help="Directory used for local temporary downloads.",
    )
    parser.add_argument("--max-concurrency", type=int, default=4, help="Maximum files to process concurrently.")
    parser.add_argument("--poll-interval-seconds", type=float, default=5.0, help="Polling interval when not running once.")
    parser.add_argument("--once", action="store_true", help="Process available files once and exit.")
    parser.add_argument("--delete-after-process", action="store_true", help="Delete object after successful processing.")
    parser.add_argument(
        "--move-to-prefix",
        default="",
        help="Move processed objects to this prefix after success. Cannot be combined with --delete-after-process.",
    )
    parser.add_argument("--log-level", default="INFO", help="Log level (DEBUG, INFO, WARNING, ERROR).")
    return parser.parse_args()


def build_s3_client(endpoint_url: str, region: str):
    return boto3.client(
        "s3",
        endpoint_url=endpoint_url,
        region_name=region,
        aws_access_key_id="test",
        aws_secret_access_key="test",
    )


def list_matching_keys(s3_client, bucket: str, prefix: str, suffix: str) -> list[str]:
    normalized_prefix = prefix.strip("/")
    paginator = s3_client.get_paginator("list_objects_v2")

    keys: list[str] = []
    for page in paginator.paginate(Bucket=bucket, Prefix=normalized_prefix):
        for obj in page.get("Contents", []):
            key = obj["Key"]
            if suffix and not key.endswith(suffix):
                continue
            keys.append(key)

    return sorted(keys)


def run_processing_command(command_prefix: Sequence[str], working_dir: Path, local_file: Path) -> tuple[int, str, str]:
    command = [*command_prefix, str(local_file)]
    completed = subprocess.run(
        command,
        cwd=str(working_dir),
        capture_output=True,
        text=True,
        check=False,
    )
    return completed.returncode, completed.stdout, completed.stderr


def download_object_to_file(s3_client, bucket: str, key: str, destination: Path) -> None:
    response = s3_client.get_object(Bucket=bucket, Key=key)
    try:
        body = response["Body"].read()
    finally:
        response["Body"].close()

    destination.write_bytes(body)


async def process_key(
    s3_client,
    bucket: str,
    key: str,
    command_prefix: Sequence[str] | None,
    working_dir: Path,
    delete_after_process: bool,
    move_to_prefix: str,
    temp_root: Path,
) -> bool:
    tmp_dir = temp_root / f"payeredi-s3-{uuid4().hex}"
    tmp_dir.mkdir(parents=True, exist_ok=False)
    local_file = tmp_dir / Path(key).name

    try:
        await asyncio.to_thread(download_object_to_file, s3_client, bucket, key, local_file)
        LOGGER.info("Downloaded s3://%s/%s", bucket, key)

        if command_prefix:
            return_code, stdout, stderr = await asyncio.to_thread(
                run_processing_command,
                command_prefix,
                working_dir,
                local_file,
            )

            if return_code != 0:
                LOGGER.error("Processing failed for key '%s' with exit code %s", key, return_code)
                if stdout.strip():
                    LOGGER.error("stdout for '%s':\n%s", key, stdout.strip())
                if stderr.strip():
                    LOGGER.error("stderr for '%s':\n%s", key, stderr.strip())
                return False

            LOGGER.info("Processed key '%s' successfully", key)
        else:
            file_size = local_file.stat().st_size
            LOGGER.info("Validated key '%s' (size=%s bytes) with built-in processor", key, file_size)

        if move_to_prefix:
            destination_key = f"{move_to_prefix.strip('/')}/{Path(key).name}"
            await asyncio.to_thread(
                s3_client.copy_object,
                Bucket=bucket,
                CopySource={"Bucket": bucket, "Key": key},
                Key=destination_key,
            )
            await asyncio.to_thread(s3_client.delete_object, Bucket=bucket, Key=key)
            LOGGER.info("Moved '%s' -> '%s'", key, destination_key)
        elif delete_after_process:
            await asyncio.to_thread(s3_client.delete_object, Bucket=bucket, Key=key)
            LOGGER.info("Deleted '%s' after successful processing", key)

        return True
    finally:
        shutil.rmtree(tmp_dir, ignore_errors=True)


async def process_batch(
    s3_client,
    bucket: str,
    keys: Sequence[str],
    command_prefix: Sequence[str] | None,
    working_dir: Path,
    max_concurrency: int,
    delete_after_process: bool,
    move_to_prefix: str,
    temp_root: Path,
) -> tuple[int, int]:
    semaphore = asyncio.Semaphore(max_concurrency)

    async def guarded_process(key: str) -> bool:
        async with semaphore:
            return await process_key(
                s3_client=s3_client,
                bucket=bucket,
                key=key,
                command_prefix=command_prefix,
                working_dir=working_dir,
                delete_after_process=delete_after_process,
                move_to_prefix=move_to_prefix,
                temp_root=temp_root,
            )

    results = await asyncio.gather(*(guarded_process(key) for key in keys))
    successes = sum(1 for result in results if result)
    failures = len(results) - successes
    return successes, failures


async def run() -> int:
    args = parse_args()

    logging.basicConfig(
        level=getattr(logging, args.log_level.upper(), logging.INFO),
        format="%(asctime)s %(levelname)s %(name)s %(message)s",
    )

    if args.max_concurrency < 1:
        raise ValueError("--max-concurrency must be at least 1.")

    if args.delete_after_process and args.move_to_prefix:
        raise ValueError("--delete-after-process cannot be combined with --move-to-prefix.")

    working_dir = Path(args.working_dir).resolve()
    if not working_dir.exists():
        raise FileNotFoundError(f"Working directory not found: {working_dir}")

    temp_root = Path(args.temp_dir).resolve()
    temp_root.mkdir(parents=True, exist_ok=True)

    s3_client = build_s3_client(args.endpoint_url, args.region)

    try:
        s3_client.head_bucket(Bucket=args.bucket)
    except ClientError as exc:
        raise RuntimeError(f"Bucket '{args.bucket}' does not exist or is not accessible") from exc

    LOGGER.info(
        "Starting S3 processor for bucket='%s' prefix='%s' suffix='%s' concurrency=%s",
        args.bucket,
        args.prefix,
        args.suffix,
        args.max_concurrency,
    )

    total_successes = 0
    total_failures = 0
    seen_keys: set[str] = set()

    while True:
        keys = await asyncio.to_thread(
            list_matching_keys,
            s3_client,
            args.bucket,
            args.prefix,
            args.suffix,
        )

        new_keys = [key for key in keys if key not in seen_keys]

        if not new_keys:
            LOGGER.info("No matching keys to process.")
        else:
            LOGGER.info("Found %s new key(s) to process.", len(new_keys))
            successes, failures = await process_batch(
                s3_client=s3_client,
                bucket=args.bucket,
                keys=new_keys,
                command_prefix=args.command,
                working_dir=working_dir,
                max_concurrency=args.max_concurrency,
                delete_after_process=args.delete_after_process,
                move_to_prefix=args.move_to_prefix,
                temp_root=temp_root,
            )
            total_successes += successes
            total_failures += failures
            seen_keys.update(new_keys)

            LOGGER.info(
                "Batch complete. successes=%s failures=%s total_successes=%s total_failures=%s",
                successes,
                failures,
                total_successes,
                total_failures,
            )

        if args.once:
            break

        await asyncio.sleep(args.poll_interval_seconds)

    return 0 if total_failures == 0 else 1


def main() -> int:
    try:
        return asyncio.run(run())
    except Exception:
        LOGGER.exception("Unhandled exception in S3 service")
        return 1


if __name__ == "__main__":
    exit_code = main()
    # Visual Studio debugger can break on SystemExit; avoid raising it while
    # debugging, but keep proper process exit codes for normal CLI runs.
    if sys.gettrace() is None:
        raise SystemExit(exit_code)