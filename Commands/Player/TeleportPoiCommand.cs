using AndroTLib.Utils;
using AndroTLib;
using Terraria.ModLoader;

namespace AndrosCommands.Commands.Player;

public class TeleportPoiCommand : ModCommand
{
    public override string Command => "telepoi";

    public override CommandType Type => CommandType.World;

    public override string Usage => "/telepoi <poi>";

    public override string Description => "Teleports the player to a point of interest";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        PointOfInterest poi = PointOfInterest.Home;

        if (args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "dungeon":
                    poi = PointOfInterest.Dungeon;
                    break;
                case "livingtree":
                    poi = PointOfInterest.LivingTree;
                    break;
                case "meteorite":
                    poi = PointOfInterest.Meteorite;
                    break;
                case "spawn":
                    poi = PointOfInterest.Spawn;
                    break;
                case "temple":
                    poi = PointOfInterest.Temple;
                    break;
                case "underworld":
                    poi = PointOfInterest.Underworld;
                    break;
            }
        }

        caller.Player.TeleportToPoi(poi);
    }
}