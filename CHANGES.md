# Changes

## 2026-11-06 — Repo cleanup (round 2)

Removed duplicate / dead source that could confuse builds or navigation:

- `Components/Pages/App.razor` (real shell is `Components/App.razor`)
- `Components/Pages/MainLayout.razor` (+ css) (real layout is `Components/Layout/MainLayout.razor`)
- `Components/Pages/TruLogo.razor` (canonical: `Components/Shared/TruLogo.razor`)
- `Components/Pages/Counter.razor` (Blazor template sample)
- `Components/Pages/HomeTopBar.snippet.razor`
- `Components/Pages/SampleChapter360.razor`, `SampleEngage.razor`
- `wwwroot/App-HEAD-SNIPPET.txt`, `wwwroot/index.html.snippet.txt`
- Polished `NotFound.razor` with clear copy and a Home link

## 2026-11-06 — Repo cleanup (round 1)

- Removed corrupted accidental filenames from PowerShell/git command output
- Removed `Routes.razor.backup`
- Removed accidental root `image.png`
- Removed 55 MB `TRU-Windows-App.zip` (prefer `dotnet publish`)
- Expanded `.gitignore` for zips, logs, secrets, and OS noise
- Rewrote `README.md` and `README_RUN.md` with accurate stack and run steps

## Earlier

See `CHANGES-SINCE-LAST-COMMIT.md` for the last major UI pass (sign-in continuous Cs, sidebar redesign, brand update).

Historical layout/fix work lives on branches such as:
- `fix/tru-platform-global-layout-v5`
- `fix/tru-layout-build-and-mainlayout-v6`
- `design/isa-premium-visual-refresh`
