# Isa — ISACA Chapter Support Assistant  
## Final complete package (ready for another computer, network, and demo / sale)

**Product name:** Isa Chapter Support Assistant  
**Type:** Blazor Server web application (.NET 10)  
**Audience:** ISACA chapter leaders (demo / prototype)

---

### What you get

- Full workspace: Knowledge base, Analytics, Events, Escalations, Governance, Risk, Compliance, Audit, Incidents, Vendor risk, Reports, Controls, Policies, Users, Translator, World clock, ISACA resources, Pipeline monitor, Developer dashboard, Isa configuration  
- Chat widget + orchestrator pipeline (search approved content → sources → hand-off)  
- Chapter 360 / leader guidance content under `content/`  
- Sign-in (Keycloak / development bypass)  
- Sample notices (20 seconds every 12 minutes)  
- Network binding so phones and other PCs on the same Wi‑Fi can open the app  

This is a **demonstration prototype**, not an official ISACA production system.  
Images and sample metrics are illustrative. Connect approved content and analytics before real use.

---

### Requirements (source run)

- Windows 10/11 (or macOS/Linux with .NET)  
- [.NET 10 SDK](https://dotnet.microsoft.com/download)  

### Requirements (published Windows folder)

- Windows 10/11 64-bit only — **no SDK required** if you used `PUBLISH_FOR_SALE.bat`

---

### Quick start on this computer

1. Unzip to a **new empty folder** (never on top of an old project).  
2. Double-click **`START_LOCAL.bat`**  
   — or in PowerShell:

```powershell
cd path\to\ISACA_Isa_Final_Complete
dotnet clean
dotnet restore
dotnet build
dotnet run --urls http://0.0.0.0:5067
```

3. Open **http://localhost:5067**  
4. Hard refresh: **Ctrl+F5**

---

### Open on phone / other PC (same network)

1. Start with **`START_NETWORK.bat`** (or the command above with `0.0.0.0`).  
2. On the host PC, run `ipconfig` and note the **IPv4 Address** (example `192.168.1.174`).  
3. On the other device (same Wi‑Fi), open:

```text
http://192.168.1.174:5067
```

4. If it does not load, allow **port 5067** in Windows Defender Firewall (inbound rule for the app or port).

---

### Package for another computer / sale demo

**Option A — source (needs .NET SDK on target)**  
Copy the whole unzipped folder. Run `START_LOCAL.bat`.

**Option B — self-contained Windows build (recommended to sell/demo)**  

```bat
PUBLISH_FOR_SALE.bat
```

Then copy folder `publish\IsaWindows` to a USB drive or the client PC and run:

```bat
IsaChatApp.exe --urls http://0.0.0.0:8080
```

Open `http://localhost:8080` or `http://PC-IP:8080`.

---

### GitHub (optional)

```powershell
git init
git branch -M main
git add .
git commit -m "Isa final complete — network ready"
git remote add origin https://github.com/YOUR_USER/YOUR_REPO.git
git push -u origin main
```

---

### License / sale note

You may demo and deliver this prototype under your own commercial terms with the client.  
Do **not** present it as an official ISACA product unless ISACA has licensed branding and content.  
ISACA names, logos, and documents remain ISACA’s property; use only with permission.

---

### Support checklist before a client demo

| Item | OK |
|------|----|
| `dotnet build` succeeds | |
| Home + sidebar pages open | |
| Chat widget opens | |
| Phone on same Wi‑Fi can open the URL | |
| Sample data notices understood as demo-only | |

Built for ISACA chapter support scenarios by Second Star Collective (i.c.stars Kansas City) prototype lineage.
