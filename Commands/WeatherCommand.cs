using System;
using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Commands;

public class WeatherCommand : ModCommand
{
    public override string Command => "weather";

    public override CommandType Type => CommandType.World;

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if(args.Length == 0)
        {
            return;
        }

        switch(args[0].ToLower())
        {
            case "clear":
                Main.StopRain();
                Main.StopSlimeRain();
                break;
            case "rain":
                PerformConditionalAction(Main.IsItRaining, Main.StopRain, Main.StartRain);
                break;
            case "slime":
                PerformConditionalAction(Main.slimeRain, () => { Main.StopSlimeRain(); }, () => { Main.StartSlimeRain(true); });
                break;
        }
    }

    private void PerformConditionalAction(bool propertyToCheck, Action trueAction, Action falseAction2)
    {
        if (propertyToCheck)
        {
            trueAction();
        }
        else
        {
            falseAction2();
        }
    }
}