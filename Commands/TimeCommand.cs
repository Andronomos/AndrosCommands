using AndrosCommands.Common;
using AndroTLib.Utils;
using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Commands;


public class TimeCommand : ModCommand
{
    private const int TimeMorning = 9000; //7am
    private const int TimeNoon = 27000; //12pm
    private const int TimeNight = 1800; //8pm

    public override string Command => "time";

    public override CommandType Type => CommandType.World;

    public override string Usage => "/time <morning|noon|night|freeze>";

    public override string Description => "Changes or freezes the time of day";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        int newTime = 0;
        bool isDayTime = false;

        if (args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "morning":
                    isDayTime = true;
                    newTime = TimeMorning;
                    break;
                case "noon":
                    isDayTime = true;
                    newTime = TimeNoon;
                    break;
                case "night":
                    isDayTime = false;
                    newTime = TimeNight;
                    break;
                case "freeze":
                    AndroCommandSystem.TimeIsFrozen = !AndroCommandSystem.TimeIsFrozen;
                    ChatUtils.DisplayInfo(ChatUtils.AsLiteral($"Time {(AndroCommandSystem.TimeIsFrozen ? "frozen" : "unfroze")}"));
                    break;
            }
        }

        if (newTime == 0)
        {
            return;
        }

        bool timeIsFrozen = AndroCommandSystem.TimeIsFrozen;
        
        //unfreeze time so we can change it
        AndroCommandSystem.TimeIsFrozen = false;

        //set the time
        Main.dayTime = isDayTime;
        Main.time = newTime;

        //if time was frozen, refreeeze at new time
        if (timeIsFrozen)
        {
            AndroCommandSystem.TimeIsFrozen = true;
        }

        ChatUtils.DisplayInfo(ChatUtils.AsLiteral("Time updated"));
    }
}