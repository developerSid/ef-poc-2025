import os
import subprocess
import sys
from pathlib import Path


def main() -> int:
    script_dir = Path(__file__).resolve().parent
    moto_script = script_dir / "run_moto_s3.py"
    venv_python = script_dir / ".venv" / "Scripts" / "python.exe"
    host = os.environ.get("PAYEREDI_S3_HOST", "127.0.0.1")
    port = os.environ.get("PAYEREDI_S3_PORT", "5000")

    python_executable = str(venv_python if venv_python.exists() else Path(sys.executable))

    if not moto_script.exists():
        print(f"Moto script not found: {moto_script}", file=sys.stderr)
        return 1

    # If explicit args are provided, forward them to moto unchanged.
    if len(sys.argv) > 1:
        args = [str(moto_script), *sys.argv[1:]]
    else:
        # Visual Studio "Run" default behavior: start moto only for test use.
        args = [str(moto_script), "--host", host, "--port", str(port)]

    process = subprocess.run([python_executable, *args], cwd=str(script_dir), check=False)
    return process.returncode


if __name__ == "__main__":
    exit_code = main()
    # Visual Studio debugger can break on SystemExit; avoid raising it while
    # debugging, but keep proper process exit codes for normal CLI runs.
    if sys.gettrace() is None:
        raise SystemExit(exit_code)