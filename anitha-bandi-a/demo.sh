#!/usr/bin/env zsh
# =============================================================================
# demo.sh — X12 EDI 837P Ingestion Demo
#
# Usage:
#   ./demo.sh local    -> Run ingestion with LOCAL file source
#   ./demo.sh s3       -> Run ingestion with S3 (Moto mock) file source
#   ./demo.sh setup    -> Start SQL container + apply DB migrations
#   ./demo.sh teardown -> Stop SQL container + kill moto server
# =============================================================================

set -euo pipefail

# ── Config ────────────────────────────────────────────────────────────────────
PROJECT="src/X12EDI837.Ingestion/X12EDI837.Ingestion.csproj"
APP_DIR="src/X12EDI837.Ingestion"

SQL_CONTAINER="sql-edge"
SQL_PASSWORD="DockerTest@123"
SQL_PORT=1433
SQL_IMAGE="mcr.microsoft.com/azure-sql-edge:latest"

MOTO_PORT=5001
MOTO_ENDPOINT="http://localhost:${MOTO_PORT}"

S3_BUCKET="edi-bucket"
S3_PREFIX="inbound"
SAMPLE_FILE="samples/837-sample-file.edi"

# ── Helpers ───────────────────────────────────────────────────────────────────
print_step() { echo "\n\033[1;34m▶ $1\033[0m"; }
print_ok()   { echo "\033[1;32m✔ $1\033[0m"; }
print_err()  { echo "\033[1;31m✘ $1\033[0m" >&2; }

# ── Commands ──────────────────────────────────────────────────────────────────

cmd_setup() {
  print_step "Starting SQL Server container..."
  if docker ps -a --format '{{.Names}}' | grep -q "^${SQL_CONTAINER}$"; then
    docker start "${SQL_CONTAINER}"
  else
    docker run --name "${SQL_CONTAINER}" \
      -e ACCEPT_EULA=Y \
      -e SA_PASSWORD="${SQL_PASSWORD}" \
      -p "${SQL_PORT}":1433 \
      -d --platform=linux/amd64 \
      "${SQL_IMAGE}"
  fi
  print_ok "SQL Server started."

  print_step "Waiting for SQL Server to be ready (15s)..."
  sleep 15

  print_step "Applying EF Core database migrations..."
  dotnet ef database update \
    -p "${PROJECT}" \
    -c HIPAA_5010_837P_Context
  print_ok "Migrations applied."
}

cmd_local() {
  print_step "Running EDI 837P ingestion — LOCAL file source"
  echo "  Reading config from: appsettings.Development.json (Provider=local)"
  echo "  File: ${SAMPLE_FILE}"
  echo ""
  cd "${APP_DIR}" && dotnet run
  print_ok "Local ingestion complete."
}

cmd_s3() {
  print_step "Starting Moto mock S3 server on port ${MOTO_PORT}..."
  moto_server -p "${MOTO_PORT}" &
  MOTO_PID=$!
  sleep 2
  print_ok "Moto server running (PID ${MOTO_PID})."

  print_step "Creating S3 bucket and uploading sample EDI file..."
  aws --endpoint-url="${MOTO_ENDPOINT}" s3 mb "s3://${S3_BUCKET}" 2>/dev/null || true
  aws --endpoint-url="${MOTO_ENDPOINT}" s3 cp \
    "${SAMPLE_FILE}" \
    "s3://${S3_BUCKET}/${S3_PREFIX}/$(basename ${SAMPLE_FILE})"
  print_ok "File uploaded to s3://${S3_BUCKET}/${S3_PREFIX}/$(basename ${SAMPLE_FILE})"

  print_step "Running EDI 837P ingestion — S3 file source"
  echo ""
  (cd "${APP_DIR}" && DOTNET_ENVIRONMENT=Production dotnet run) || true

  print_step "Stopping Moto server..."
  kill "${MOTO_PID}" 2>/dev/null || true
  print_ok "Moto server stopped."
}

cmd_teardown() {
  print_step "Stopping SQL Server container..."
  docker stop "${SQL_CONTAINER}" 2>/dev/null && print_ok "SQL Server stopped." || echo "  (already stopped)"

  print_step "Killing any Moto server on port ${MOTO_PORT}..."
  PIDS=$(lsof -ti:"${MOTO_PORT}" 2>/dev/null || true)
  if [[ -n "${PIDS}" ]]; then
    kill "${PIDS}"
    print_ok "Moto server killed."
  else
    echo "  (no moto process found)"
  fi
}

# ── Entrypoint ────────────────────────────────────────────────────────────────
case "${1:-help}" in
  setup)    cmd_setup    ;;
  local)    cmd_local    ;;
  s3)       cmd_s3       ;;
  teardown) cmd_teardown ;;
  *)
    echo ""
    echo "Usage: ./demo.sh <command>"
    echo ""
    echo "  setup     -> Start SQL container + apply DB migrations"
    echo "  local     -> Run ingestion with LOCAL file source"
    echo "  s3        -> Run ingestion with S3 (Moto mock) file source"
    echo "  teardown  -> Stop SQL container + kill Moto server"
    echo ""
    ;;
esac
