using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Common.Commands;

public class OpenRandomCrateCommand : ModCommand
{
    private readonly Random _random = new();

    public override string Command => "randomcrate";

    public override CommandType Type => CommandType.World;

    public override string Usage => "/randomcrate <normal|hard|both> <amount>";

    public override string Description => "Opens a random crate";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        int amount = 1;
        List<int> crates = [];

        if (!string.IsNullOrEmpty(args[0]))
        {
            string chosenType = args[0].ToLower();

            switch (chosenType)
            {
                case "normal":
                    crates = ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrate);
                    break;
                case "hard":
                    crates = ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrateHardmode);
                    break;                                    
                case "both":
                default:
                    crates = ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrate);
                    crates.AddRange(ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrateHardmode));
                    break;
            }
        }

        if (args.Length == 2)
        {
            if (!int.TryParse(args[1], out amount))
            {
                throw new UsageException($"Amount value must be integer, but met: {args[1]}");
            }
        }

        for (int i = 0; i < amount; i++)
        {
            int chosenCrate = crates[_random.Next(0, crates.Count)];
            BroadcastUtils.BroadcastInfo($"Opening {Lang.GetItemNameValue(chosenCrate)}");
            caller.Player.OpenFishingCrate(chosenCrate);
        }      
    }
}