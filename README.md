# TRU / IsaChatApp

**Trusted Resource & Unified Support** — a Blazor Server platform for knowledge, chat, analytics, governance, compliance, and onboarding, built for ISACA-related workflows.

## Stack

| Layer | Technology |
|-------|------------|
| Frontend | Blazor Server (.NET 10), HTML5, CSS3 |
| Backend | C#, ASP.NET Core, Cookie auth |
| Data | SQLite (content, events, onboarding, notebooks) |
| Auth | Keycloak (optional) + cookie sign-in |
| AI pipeline | Orchestrator with staged RAG / compliance / translation stages |

## Quick start

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (Optional) Keycloak if you want full SSO

### Run locally

```bash
# From the repo root
dotnet restore TRU-ChatApp.csproj
dotnet run --project TRU-ChatApp.csproj
```

Or use the helper scripts:

- `START_LOCAL.bat` / `start-TRU.bat` — start the app
- `check-prereqs.ps1` — verify tools

Then open the URL shown in the console (usually `https://localhost:5xxx` or `http://localhost:5xxx`).

Sign-in page: `/sign-in`

## Project layout

```
Components/
  App.razor          # Root HTML shell
  Routes.razor       # Router + default MainLayout
  Layout/            # MainLayout, NavMenu, ChatWidget, Auth/Landing layouts
  Pages/             # Feature pages (Home, SignIn, Analytics, KnowledgeBase, …)
Services/
  Orchestrator/      # Multi-stage AI pipeline
  Onboarding/        # Journey, progress, notebook, handoff
wwwroot/             # Static CSS, images, logos, bootstrap
content/             # Source content for the knowledge base
data/                # Runtime SQLite DBs (gitignored)
keycloak/            # Local Keycloak config (optional)
```

## Configuration

- `appsettings.json` — DB paths, Keycloak authority, access-control flags
- `dev-keys.example.json` → copy to `dev-keys.json` (gitignored) for API keys
- Developer Dashboard page can also hold keys at runtime

## Branding

See `BRAND_GUIDELINES.md` and the CSS under `wwwroot/css/` and `wwwroot/lib-dist/css/`.

Primary colors lean on deep navy + teal/green accents (ISACA-inspired).

## Notes

- Large binary `TRU-Windows-App.zip` is a packaged build; prefer source + `dotnet publish` for development.
- Several historical layout-fix branches exist; `main` is the integration line.
- Build CI: `.github/workflows/dotnet-build.yml` (Windows + .NET 10).

---

Principal developer: **Elias**  
Focus: modular Blazor components, local/LLM-friendly pipelines, maintainable enterprise UI.
