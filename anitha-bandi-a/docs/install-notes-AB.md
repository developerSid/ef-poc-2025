# Started with previously installed dotnet-cli
```
brew install --cask dotnet-sdk
dotnet tool install --global dotnet-ef
```

# Installed .Net 8.0
```
https://dotnet.microsoft.com/en-us/download/dotnet/8.0
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.121-macos-arm64-installer
```

Verify it is there:
```
➜  ef-poc-2025 git:(clints-branch) dotnet --list-sdks   

8.0.121 [/usr/local/share/dotnet/sdk]
9.0.305 [/usr/local/share/dotnet/sdk]
```

# Create the Solution and Project Files
```
dotnet new sln -n X12EDI837.Ingestion
dotnet new console -n X12EDI837.Ingestion -o src/X12EDI837.Ingestion --framework net8.0 --force
dotnet new xunit -n X12EDI837.Ingestion.Tests -o tests/X12EDI837.Ingestion.Tests --framework net8.0 --force
dotnet sln add src/X12EDI837.Ingestion tests/X12EDI837.Ingestion.Tests
dotnet add tests/X12EDI837.Ingestion.Tests reference src/X12EDI837.Ingestion
```


# Add the packages
## Ingestion project
```
dotnet add package EdiFabric
dotnet add package EdiFabric.Templates.Hipaa
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 8.0.0
dotnet add package Microsoft.Extensions.Hosting --version 8.0.1
```


## Tests project
```
dotnet add package xunit
dotnet add package xunit.runner.console
dotnet add package coverlet.collector
dotnet tool install --global dotnet-reportgenerator-globaltool
dotnet add package Moq
```


# Previously had SQL Server running
```
# Pull the latest SQL Server 2022 image (Apple Mac version)
docker pull mcr.microsoft.com/azure-sql-edge:latest


# Apple Silicon (ARM64 / M1/M2/M3/M4) - SQL Server via Azure SQL Edge
```
# Microsoft does not provide a native ARM64 SQL Server 2022 image.
# Use Azure SQL Edge, which is ARM64-compatible and suitable for local dev.

docker pull mcr.microsoft.com/azure-sql-edge:latest

# Run it (replace YourStrongPassword! with your real password)
docker run -e "ACCEPT_EULA=1" \
           -e "MSSQL_SA_PASSWORD=YourStrongPassword!" \
           -p 1433:1433 \
           --name sql-edge \
           --platform linux/arm64 \
           -d mcr.microsoft.com/azure-sql-edge:latest

docker start sql-edge
```

> Note: Azure SQL Edge uses `ACCEPT_EULA=1` (not `Y`) and `MSSQL_SA_PASSWORD` (not `SA_PASSWORD`).
> The connection string remains the same: `Server=localhost,1433;User Id=sa;Password=YourStrongPassword!`

# Install Moto
```
pip install "moto[s3,server]"
```

# Install AWS Packages
```
 dotnet add package AWSSDK.Core
 dotnet add package AWSSDK.S3
 ```

 # Linters/Formatters
 ```
dotnet add package Microsoft.CodeAnalysis.CSharp.CodeStyle
dotnet tool install -g csharpier
```