import argparse

from moto.server import main as moto_server_main
from config_loader import get_required, load_config


def parse_args() -> argparse.Namespace:
    config = load_config()

    parser = argparse.ArgumentParser(description="Run a local moto S3 server.")
    parser.add_argument("--host", default=str(get_required(config, "S3.Moto.Host")), help="Bind host.")
    parser.add_argument("--port", default=str(get_required(config, "S3.Moto.Port")), help="Bind port.")
    return parser.parse_args()


if __name__ == "__main__":
    args = parse_args()
    moto_server_main(["-H", args.host, "-p", str(args.port)])
