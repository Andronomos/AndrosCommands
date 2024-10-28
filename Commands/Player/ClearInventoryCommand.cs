using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Commands.Player;

public class ClearInventoryCommand : ModCommand
{
    public override string Command => "clearinventory";

    public override string Description => "Clears the player's inventory";

    public override string Usage => "/clearinventory <true|false>" +
        "true - removes locked items" +
        "false - skips locked items";

    public override CommandType Type => CommandType.World;

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        Terraria.Player player = caller.Player;
        bool clearAll = false;

        if (args.Length > 0)
        {
            if (!string.IsNullOrEmpty(args[0]))
            {
                _ = bool.TryParse(args[0], out clearAll);
            }
        }

        for (int i = 0; i < player.inventory.Length; i++)
        {
            Item item = player.inventory[i];

            if (item == null || item.IsAir)
            {
                continue;
            }

            if (!clearAll && player.inventory[i].favorited)
            {
                continue;
            }

            player.inventory[i] = new();
        }
    }
}