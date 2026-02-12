# Database Setup & EF Core Migrations (net10)

The PayerEdi.Pharmacy.Data project uses **EF Core migrations** with a **design-time DbContext
factory**.\
No web project, no startup project, and no DI configuration is required.

------------------------------------------------------------------------

## Prerequisites (one-time per machine)

Install the EF Core CLI tool:

``` bash
dotnet tool install --global dotnet-ef
```

Verify installation:

``` bash
dotnet ef --version
```

------------------------------------------------------------------------

## Configure the Database Connection

Set the connection string using the `HIPAA_DB_CONNECTION` environment variable.

### PowerShell (per shell)

```powershell
setx HIPAA_DB_CONNECTION "Server=.\SQLEXPRESS;Database=HipaaDev;Trusted_Connection=True;TrustServerCertificate=True;" /M
```

You may change the database name (`HipaaDev`) as needed.

------------------------------------------------------------------------

## Create the Initial Migration

Run from the folder that contains the `.csproj` with the `DbContext`:

``` bash
dotnet ef migrations add InitialCreate
```

------------------------------------------------------------------------

## Create / Update the Database

Apply migrations to the database:

``` bash
dotnet ef database update
```

------------------------------------------------------------------------

## Add a New Migration (after model changes)

``` bash
dotnet ef migrations add AddSomeFeature
dotnet ef database update
```

------------------------------------------------------------------------

## Useful Commands

List migrations:

``` bash
dotnet ef migrations list
```

Drop and recreate the database (local development only):

``` bash
dotnet ef database drop --force
dotnet ef database update
```

------------------------------------------------------------------------

## Assumptions

-   The project contains a **concrete DbContext**
-   The project contains an **IDesignTimeDbContextFactory**
-   No web project or startup project is required
