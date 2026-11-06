# Changes

## 2026-11-06 — Repo cleanup

- Removed corrupted accidental filenames that were created from PowerShell/git command output
- Removed `Routes.razor.backup`
- Removed accidental root `image.png`
- Removed 55 MB `TRU-Windows-App.zip` from the source tree (prefer `dotnet publish`)
- Expanded `.gitignore` for zips, logs, secrets, and OS noise
- Rewrote `README.md` with accurate stack, layout, and run instructions

## Earlier

See `CHANGES-SINCE-LAST-COMMIT.md` for the last major UI pass (sign-in continuous Cs, sidebar redesign, brand update).

Historical layout/fix work lives on branches such as:
- `fix/tru-platform-global-layout-v5`
- `fix/tru-layout-build-and-mainlayout-v6`
- `design/isa-premium-visual-refresh`
