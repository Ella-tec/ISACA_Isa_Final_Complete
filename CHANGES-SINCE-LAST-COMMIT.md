# Changes since last commit (for Matthew)

## Summary
Full ISACA brand update: sign-in continuous crossing Cs + modern workspace sidebar.

## Sign-in page
- Large continuous crossing Cs (never stop)
- Colors shift (Blue / Teal / Medium Blue / Green)
- Small badge removed

## Sidebar / NavMenu (new design)
- Dark navy gradient shell (ISACA Dark Blue)
- Green C mark in white rounded tile
- Clean icon + label rows, active state with cyan accent
- Section labels: Workspace + Developer
- **Get started** button: black bar + lime green chevron chip (from your reference)
- Settings link at bottom
- Sticky sidebar, polished top bar

## Files to apply

| File | Action |
|------|--------|
| Components/Pages/SignIn.razor | Replace |
| Components/Pages/SignIn.razor.css | Replace |
| Components/Layout/NavMenu.razor | **Replace / Add** |
| Components/Layout/NavMenu.razor.css | **Replace / Add** |
| Components/Layout/MainLayout.razor | Replace |
| Components/Layout/MainLayout.razor.css | **Add** (new) |
| Components/Pages/Home.razor | Replace if present |
| Components/Pages/Home.razor.css | Replace if present |
| wwwroot/app.css | Replace if present |
| wwwroot/images/* | Add / replace as listed |

## How to apply in VS Code
1. Extract the zip
2. Copy files into the same paths in your project
3. If `NavMenu.razor` already exists, replace it entirely
4. `dotnet run` then Ctrl+Shift+R in browser

Matthew: please commit when ready. Grok does not commit.
