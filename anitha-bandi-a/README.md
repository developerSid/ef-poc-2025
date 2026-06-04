# X12 EDI 837 Ingestion

A .NET 8 solution for ingesting and processing **X12 EDI 837** healthcare claim files.

---

## 📁 Solution Structure

```
anitha-bandi-a.sln
├── src/
│   └── X12EDI837.Ingestion/          # Main ingestion application
│       ├── Program.cs
│       ├── appsettings.json
│       └── X12EDI837.Ingestion.csproj
├── tests/
│   └── X12EDI837.Ingestion.Tests/    # xUnit unit tests
│       └── X12EDI837.Ingestion.Tests.csproj
├── samples/
│   ├── 837-sample-file.edi
│   ├── 837-sample-file-2.edi
│   └── 837-sample-file-unexpected-segment.edi
└── docs/
    ├── building-and-running-AB.md
    ├── install-notes-AB.md
    └── testing.md
```

---

## 🚀 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- See [docs/install-notes-AB.md](docs/install-notes-AB.md) for additional setup notes

---

## 🔧 Build

```sh
dotnet build anitha-bandi-a.sln
```

Or using Make:

```sh
make build
```

---

## ▶️ Run

```sh
dotnet run --project src/X12EDI837.Ingestion
```

See [docs/building-and-running -AB.md](docs/building-and-running%20-AB.md) for detailed instructions.

---

## 🧪 Testing

Run all unit tests:

```sh
dotnet test anitha-bandi-a.sln
```

Or target the test project directly:

```sh
dotnet test tests/X12EDI837.Ingestion.Tests
```

See [docs/testing.md](docs/testing.md) for more details.

---

## 📦 Key Dependencies

| Package | Purpose |
|---|---|
| `EdiFabric` | X12 EDI parsing |
| `EdiFabric.Templates.Hipaa` | HIPAA 837 templates |
| `Microsoft.EntityFrameworkCore.InMemory` | In-memory data store |
| `xunit` | Unit testing framework |
| `Moq` | Mocking library |

---

## 📄 Sample EDI Files

Sample 837 EDI files are available in the [`samples/`](samples/) directory for local testing.

---

## 📚 Documentation

- [Building & Running](docs/building-and-running%20-AB.md)
- [Install Notes](docs/install-notes-AB.md)
- [Testing](docs/testing.md)