import json
from pathlib import Path
from typing import Any


def get_default_config_path() -> Path:
    current = Path(__file__).resolve().parent
    while current is not None:
        if (current / "PayerEdi.Pharmacy.slnx").exists():
            return current / "appsettings.json"
        parent = current.parent
        if parent == current:
            break
        current = parent

    raise FileNotFoundError("Could not resolve repository root appsettings.json.")


def load_config(config_path: Path | None = None) -> dict[str, Any]:
    resolved_path = config_path or get_default_config_path()
    with resolved_path.open("r", encoding="utf-8") as config_file:
        return json.load(config_file)


def get_required(config: dict[str, Any], path: str) -> Any:
    current: Any = config
    for key in path.split("."):
        if not isinstance(current, dict) or key not in current:
            raise KeyError(f"Missing required configuration key: {path}")
        current = current[key]
    return current
