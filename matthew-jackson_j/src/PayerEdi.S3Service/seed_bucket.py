import argparse
from pathlib import Path

import boto3


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Upload sample EDI files to a moto S3 bucket.")
    parser.add_argument("--endpoint-url", default="http://127.0.0.1:5000", help="Moto S3 endpoint URL.")
    parser.add_argument("--region", default="us-east-1", help="AWS region.")
    parser.add_argument("--bucket", required=True, help="Target bucket.")
    parser.add_argument("--source-dir", default="samples", help="Directory containing EDI files.")
    parser.add_argument("--glob", default="*.edi", help="Glob pattern for files.")
    parser.add_argument("--prefix", default="", help="Optional S3 key prefix.")
    return parser.parse_args()


def create_client(endpoint_url: str, region: str):
    return boto3.client(
        "s3",
        endpoint_url=endpoint_url,
        region_name=region,
        aws_access_key_id="test",
        aws_secret_access_key="test",
    )


def ensure_bucket(s3_client, bucket: str, region: str) -> None:
    if region == "us-east-1":
        s3_client.create_bucket(Bucket=bucket)
        return

    s3_client.create_bucket(
        Bucket=bucket,
        CreateBucketConfiguration={"LocationConstraint": region},
    )


def main() -> int:
    args = parse_args()
    source_dir = Path(args.source_dir).resolve()
    if not source_dir.exists():
        raise FileNotFoundError(f"Source directory not found: {source_dir}")

    files = sorted(source_dir.glob(args.glob))
    if not files:
        print(f"No files found for pattern '{args.glob}' under {source_dir}")
        return 0

    s3_client = create_client(args.endpoint_url, args.region)
    try:
        ensure_bucket(s3_client, args.bucket, args.region)
    except s3_client.exceptions.BucketAlreadyOwnedByYou:
        pass
    except s3_client.exceptions.BucketAlreadyExists:
        pass

    prefix = args.prefix.strip("/")
    uploaded = 0
    for file_path in files:
        key = file_path.name if not prefix else f"{prefix}/{file_path.name}"
        s3_client.upload_file(str(file_path), args.bucket, key)
        print(f"Uploaded {file_path.name} -> s3://{args.bucket}/{key}")
        uploaded += 1

    print(f"Uploaded {uploaded} file(s).")
    return uploaded


if __name__ == "__main__":
    main()