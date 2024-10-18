using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AndrosCommands.Common.Commands;

public class BossBagCommand : ModCommand
{
    private readonly Random _random = new();

    public override string Command => "bossbag";

    public override CommandType Type => CommandType.World;

    public override string Description => "Opens a random boss bag";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        int amount = 1;
        List<int> bags = ItemIdUtils.GetItemsInSet(ItemID.Sets.BossBag);

        if (!string.IsNullOrEmpty(args[0]))
        {
            if (!int.TryParse(args[0], out amount))
            {
                throw new UsageException($"Amount value must be integer, but met: {args[0]}");
            }
        }

        for (int i = 0; i < amount; i++)
        {
            int chosenBag = bags[_random.Next(0, bags.Count)];
            BroadcastUtils.BroadcastInfo($"Opening {Lang.GetItemNameValue(chosenBag)}");
            caller.Player.OpenBossBag(chosenBag);
        }
    }
}