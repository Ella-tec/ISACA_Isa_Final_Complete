# ISACA Isa — Final Complete Version

Chapter support assistant prototype for ISACA chapter leaders.

## Requirements
- .NET 10 SDK (or newer)
- Optional: Ollama at localhost:11434 for local LLM
- Optional: Keycloak (docker-compose included)

## Run (Windows PowerShell)

```powershell
cd path\to\ISACA_Isa_Final_Complete

dotnet clean
dotnet restore
dotnet build
dotnet run
```

Open the URL shown in the terminal (e.g. http://localhost:5067).

Hard-refresh the browser after first load: **Ctrl+F5**.

## Push to GitHub

```powershell
git init
git branch -M main
git add .
git commit -m "ISACA Isa final complete version"
git remote add origin https://github.com/Ella-tec/ISACA_Isa_Last_Version.git
git push -u origin main
```

(If remote already exists: `git remote set-url origin https://github.com/Ella-tec/ISACA_Isa_Last_Version.git`)

## What is included
- Full workspace pages: Analytics, Knowledge base, Events, Escalations, Governance, Risk, Compliance, Audit, Incidents, Vendor, Reports, Controls, Policies, Users, Translator, World clock, ISACA resources, Pipeline monitor, Content health, Developer dashboard, Isa config
- Chat widget + orchestrator pipeline stages
- Sample notices (show 20 seconds every 12 minutes)
- ISACA Chapter 360 content under /content
- Sign-in (Keycloak / dev bypass)

## Demo notes
- Sample data only — not production
- DevBypass access control may be ON in Development
- Connect approved analytics/content sources before real use
