# How to run TRU / IsaChatApp

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows recommended for the helper `.bat` / `.ps1` scripts (Linux/macOS: use `dotnet` directly)
- Optional: Docker + Keycloak if you need the full SSO path

## Fastest path

```bash
cd path/to/ISACA_Isa_Final_Complete
dotnet restore TRU-ChatApp.csproj
dotnet run --project TRU-ChatApp.csproj
```

Open the HTTPS/HTTP URL printed in the terminal.

Sign-in: `/sign-in`

## Helper scripts (Windows)

| Script | Purpose |
|--------|--------|
| `START_LOCAL.bat` | Start for local use |
| `start-TRU.bat` / `start-TRU-debug.bat` | Launch helpers |
| `check-prereqs.ps1` | Verify .NET and tools |
| `stop-isa.bat` / `stop-isa-debug.bat` | Stop processes |
| `watch-TRU.ps1` | Watch mode |

## Config

1. Copy `dev-keys.example.json` → `dev-keys.json` (optional; gitignored).
2. Adjust `appsettings.json` / `appsettings.Development.json` for DB paths and Keycloak.
3. SQLite files under `data/` are created at runtime.

## Keycloak (optional)

See the `keycloak/` folder and `reset-keycloak*.bat|ps1` scripts.
Default authority in config: `http://localhost:8080/realms/isa`.

## Build only

```bash
dotnet build TRU-ChatApp.csproj -c Release
```

CI does the same on push to `main` (Windows runner + .NET 10).
