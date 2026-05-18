# AdminBraziers

Admin-focused metal braziers and fire cages for Vintage Story 1.22.x.

`AdminBraziers` adds decorative, always-burning braziers and fire cages intended for server-managed areas such as spawn towns, public roads, markets, inns, temples, arenas, and protected settlements.

The mod is especially useful when staff want permanent atmospheric light sources without having to refill fuel manually.

## Admin Mode

The mod includes a server configuration file:

- `adminMode`: enables admin-oriented behavior.
- `removeCraftingRecipesWhenAdminModeEnabled`: removes survival crafting recipes when admin mode is enabled.
- `adminPrivileges`: privileges that count as admin when recipes are kept but admin mode remains enabled.

With the default configuration, players cannot craft these braziers in survival. Server staff can still place them using creative mode, `/give`, WorldEdit, or other admin tooling. By default, the admin privilege check uses `root`, which matches the vanilla `admin` role.

Example configuration:

```json
{
  "adminMode": true,
  "removeCraftingRecipesWhenAdminModeEnabled": true,
  "adminPrivileges": [
    "root"
  ]
}
```

## Relationship With Braziers

This mod is based on the original `Braziers` mod:

https://mods.vintagestory.at/braziers

The original mod adds decorative permanent braziers and fire cages.

`AdminBraziers` keeps that decorative use case but focuses on server-managed areas. It adds a separate mod identity, a separate asset domain, and configuration to make these blocks admin-only by removing survival crafting recipes when desired.

Use the original mod if you want normal decorative braziers available to players through survival crafting. Use `AdminBraziers` if you want staff-controlled permanent braziers for public or protected server builds.

## Usage

1. Install the mod on both server and clients.
2. Start the server once to generate `ModConfig/adminbraziers.json`.
3. Keep `adminMode` enabled if the braziers should be admin-only.
4. Restart the server after changing recipe-related configuration.
5. Place the braziers manually in server-managed areas.

## Build

Set `VINTAGE_STORY` to your Vintage Story installation path, then build:

```powershell
$env:VINTAGE_STORY = "C:\Path\To\VintageStory"
dotnet build .\AdminBraziers.csproj -c Release
```

## Compatibility

- Vintage Story `1.22.0`
- Vintage Story `1.22.1`
- Vintage Story `1.22.2`

## Credits

- Author: `spasmos`
- Contributors: `Digitalr (Just_a_cat)`, `DazPrinzip`
- Based on the original `Braziers` mod

## Changelog 1.0.0

- First release as `AdminBraziers`
- Renamed the project and mod identity to avoid confusion with the original mod
- Added explicit relationship notes for the original `Braziers` mod
- Added `adminbraziers.json` configuration
- Added optional admin-only mode by removing survival crafting recipes
- Kept the decorative permanent brazier and fire cage use case
