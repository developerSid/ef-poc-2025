import argparse
from pathlib import Path

import boto3
from config_loader import get_required, load_config


def parse_args() -> argparse.Namespace:
    config = load_config()

    parser = argparse.ArgumentParser(description="Upload sample EDI files to a moto S3 bucket.")
    parser.add_argument("--endpoint-url", default=get_required(config, "S3.EndpointUrl"), help="Moto S3 endpoint URL.")
    parser.add_argument("--region", default=get_required(config, "S3.Region"), help="AWS region.")
    parser.add_argument("--access-key", default=get_required(config, "S3.AccessKey"), help="S3 access key.")
    parser.add_argument("--secret-key", default=get_required(config, "S3.SecretKey"), help="S3 secret key.")
    parser.add_argument("--bucket", default=get_required(config, "S3.Bucket"), help="Target bucket.")
    parser.add_argument("--source-dir", default=get_required(config, "Seeder.SourceDir"), help="Directory containing EDI files.")
    parser.add_argument("--glob", default=get_required(config, "Seeder.Glob"), help="Glob pattern for files.")
    parser.add_argument("--prefix", default=get_required(config, "S3.Prefix"), help="Optional S3 key prefix.")
    return parser.parse_args()


def create_client(endpoint_url: str, region: str, access_key: str, secret_key: str):
    return boto3.client(
        "s3",
        endpoint_url=endpoint_url,
        region_name=region,
        aws_access_key_id=access_key,
        aws_secret_access_key=secret_key,
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

    s3_client = create_client(args.endpoint_url, args.region, args.access_key, args.secret_key)
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
