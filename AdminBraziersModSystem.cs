using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace AdminBraziers;

public sealed class AdminBraziersModSystem : ModSystem
{
    private const string ConfigFileName = "adminbraziers.json";
    private const string ModDomain = "adminbraziers";

    private ICoreServerAPI? sapi;
    private AdminBraziersConfig config = new();

    public override double ExecuteOrder()
    {
        return 1.1;
    }

    public override void Start(ICoreAPI api)
    {
        if (api.Side != EnumAppSide.Server)
        {
            return;
        }

        sapi = (ICoreServerAPI)api;
        LoadConfig();
        api.Event.MatchesGridRecipe += OnMatchesGridRecipe;
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        sapi = api;
        RegisterCommands(api);
    }

    public override void AssetsFinalize(ICoreAPI api)
    {
        if (api.Side != EnumAppSide.Server || !config.AdminMode || !config.RemoveCraftingRecipesWhenAdminModeEnabled)
        {
            return;
        }

        int removed = api.World.GridRecipes.RemoveAll(IsForkedBrazierRecipe);
        api.Logger.Notification("[adminbraziers] Admin mode enabled. Removed {0} survival crafting recipe(s).", removed);
    }

    public override void Dispose()
    {
        if (sapi != null)
        {
            sapi.Event.MatchesGridRecipe -= OnMatchesGridRecipe;
        }
    }

    private void LoadConfig()
    {
        if (sapi == null)
        {
            return;
        }

        config = sapi.LoadModConfig<AdminBraziersConfig>(ConfigFileName) ?? new AdminBraziersConfig();
        sapi.StoreModConfig(config, ConfigFileName);
    }

    private void RegisterCommands(ICoreServerAPI api)
    {
        api.ChatCommands.Create("adminbraziers")
            .WithDescription("Manage AdminBraziers configuration")
            .RequiresPrivilege(Privilege.controlserver)
            .BeginSubCommand("reload")
                .WithDescription("Reload adminbraziers.json. Recipe changes require a server restart.")
                .HandleWith(OnReloadCommand)
                .EndSubCommand();
    }

    private TextCommandResult OnReloadCommand(TextCommandCallingArgs args)
    {
        LoadConfig();
        return TextCommandResult.Success("adminbraziers config reloaded. Restart the server for recipe changes to fully apply.");
    }

    private static bool IsForkedBrazierRecipe(GridRecipe recipe)
    {
        string? domain = recipe.Output?.Code?.Domain;
        string? path = recipe.Output?.Code?.Path;

        return domain == ModDomain
            && (path?.StartsWith("brazier-", StringComparison.OrdinalIgnoreCase) == true
                || path?.StartsWith("firecage-", StringComparison.OrdinalIgnoreCase) == true);
    }

    private bool OnMatchesGridRecipe(IPlayer player, GridRecipe recipe, ItemSlot[] ingredients, int gridWidth)
    {
        if (!config.AdminMode || config.RemoveCraftingRecipesWhenAdminModeEnabled || !IsForkedBrazierRecipe(recipe))
        {
            return true;
        }

        return IsAdminPlayer(player);
    }

    private bool IsAdminPlayer(IPlayer player)
    {
        foreach (string privilege in config.AdminPrivileges)
        {
            if (player.HasPrivilege(privilege))
            {
                return true;
            }
        }

        return false;
    }
}

public sealed class AdminBraziersConfig
{
    public bool AdminMode { get; set; } = true;

    public bool RemoveCraftingRecipesWhenAdminModeEnabled { get; set; } = true;

    public string[] AdminPrivileges { get; set; } = { Privilege.root };
}
