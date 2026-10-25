# ISACA Brand Visual Style Update — Isa App

Aligned the sign-in page, logos, shared design tokens, and features list with
https://brand.isaca.org/visual-style (and the repo BRAND_GUIDELINES.md).

## What changed

### 1. New / updated C logos (wwwroot/images/)
- **isa-c-logo.svg** — circular green-to-teal C mark on white (matches the sign-in badge treatment in the brand screenshots).
- **isa-mark.svg** — compact navy tile with green C for top bars / nav.
- **isa-logo.svg** — full square lockup with “Isa” + CHAPTER SUPPORT.

### 2. Sign-in page (Components/Pages/SignIn.razor + .css)
- Replaced single flat C with a **cropped multi-C pattern** (large cropped C + overlapping secondary Cs) that bleeds off the panel — per “CROPPED C GRAPHIC” and pattern guidance.
- Badge now uses the new green C logo instead of the Throbber placeholder.
- Exact primary / secondary / greyscale tokens from the palette.
- Typography: Roboto Light body, Roboto Slab Light headlines, Roboto Bold ALL CAPS for labels/tag.
- Contrast: dark blue / grey-9 on light surfaces; white / light text on dark blue (meets preferred ≥7:1 and minimum ≥4.5:1).

### 3. Home / features list (Components/Pages/Home.razor)
- Hero badge uses the new C logo.
- Feature cards rewritten with clearer, benefit-oriented descriptions (different and more polished).
- Grouped around chapter-leader jobs-to-be-done (guidance, operations, risk/compliance, support).

### 4. Shared design system (wwwroot/app.css)
- CSS variables expanded to the full primary / secondary / tertiary / greyscale set from the guidelines.
- Body defaults to Roboto Light + Grey 9; headings use Roboto Slab Light.

## How to apply
Copy the files in this folder over the matching paths in your clone of
https://github.com/Ella-tec/ISACA_Isa_Final_Complete

```bash
# from repo root
cp -R path/to/ISACA_Isa_Brand_Update/Components/Pages/* Components/Pages/
cp path/to/ISACA_Isa_Brand_Update/wwwroot/app.css wwwroot/
cp path/to/ISACA_Isa_Brand_Update/wwwroot/images/* wwwroot/images/
```

Then rebuild / refresh the app (e.g. `dotnet run` or your START_*.bat).

## Brand references used
- Primary: Dark Blue #1d2d5c, Blue #00a4e4, Green #6cb33f
- Secondary: Medium Blue #07649d, Teal #36ac91, Light Blue #e7f0f5
- Tertiary: Red #e31837, Orange #e57524, Yellow #fbb034, Purple #6558b1
- Type: Roboto (primary), Roboto Slab (enhancement), Roboto Condensed (secondary)
- Visual motif: rotating / cropped / patterned Cs
- Accessibility: WCAG 2.1 AA (min 4.5:1) / AAA preferred (7:1)
