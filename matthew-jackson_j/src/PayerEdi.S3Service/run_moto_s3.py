import argparse

from moto.server import main as moto_server_main


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Run a local moto S3 server.")
    parser.add_argument("--host", default="127.0.0.1", help="Bind host.")
    parser.add_argument("--port", default="5000", help="Bind port.")
    return parser.parse_args()


if __name__ == "__main__":
    args = parse_args()
    moto_server_main(["-H", args.host, "-p", str(args.port)])