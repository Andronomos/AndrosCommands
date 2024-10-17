using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AndrosCommands.Common.Commands;

public class ChestCommand : ModCommand
{
    private readonly Random _random = new();

    public override string Command => "getchest";

    public override CommandType Type => CommandType.World;

    public override string Description => "Locates all of the chests in the world and moves them to the player";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        List<int> crates = ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrate);
        List<int> hardCrates = ItemIdUtils.GetItemsInSet(ItemID.Sets.IsFishingCrateHardmode);

        BroadcastUtils.BroadcastInfo($"crates length: {crates.Count}");
        BroadcastUtils.BroadcastInfo($"hardCrates length: {hardCrates.Count}");

        int chosenCrate = crates[_random.Next(0, crates.Count)];

        BroadcastUtils.BroadcastInfo($"chosen crate: {Lang.GetItemNameValue(chosenCrate)}");

        caller.Player.OpenFishingCrate(chosenCrate);
    }
}