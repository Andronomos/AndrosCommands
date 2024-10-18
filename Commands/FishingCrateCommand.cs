using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Commands;

public class FishingCrateCommand : ModCommand
{
    private readonly Random _random = new();

    public override string Command => "fishingcrate";

    public override CommandType Type => CommandType.World;

    public override string Usage => "/fishingcrate <normal|hard> <amount>";

    public override string Description => "Opens a random crate";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        int amountToOpen = 1;
        List<int> crates = ItemIdUtils.GetItemsInSets([ItemID.Sets.IsFishingCrate, ItemID.Sets.IsFishingCrateHardmode]);

        if (args.Length > 0)
        {
            if (!int.TryParse(args[0], out amountToOpen))
            {
                amountToOpen = 1;
                string chosenType = args[0].ToLower();

                crates = chosenType switch
                {
                    "hard" => ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrateHardmode),
                    _ => ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrate),
                };
            }

            if (args.Length == 2)
            {
                if (!int.TryParse(args[1], out amountToOpen))
                {
                    throw new UsageException($"Amount value must be integer, but met: {args[1]}");
                }
            }
        }

        for (int i = 0; i < amountToOpen; i++)
        {
            int chosenCrate = crates[_random.Next(0, crates.Count)];
            BroadcastUtils.BroadcastInfo($"Opening {Lang.GetItemNameValue(chosenCrate)}");
            caller.Player.OpenFishingCrate(chosenCrate);
        }
    }
}