using Terraria;
using Terraria.ModLoader;

namespace AndrosCommands.Commands;


public class TimeCommand : ModCommand
{
    public override string Command => "time";

    public override CommandType Type => CommandType.World;

    public override string Usage => "/time <morning|noon|night|freeze>";

    public override string Description => "Changes or freezes the time of day";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        //day
        //night
        //freeze

        if (args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "morning":
                    Main.dayTime = true;
                    Main.time = 9000; //7am
                    //Main.time = 12600; //8am
                    break;
                case "noon":
                    Main.dayTime = true;
                    Main.time = 27000; //Noon
                    break;
                case "night":
                    Main.dayTime = false;
                    Main.time = 1800; //8pm
                    break;
                case "freeze":
                    break;
            }
        }


        //Main.dayTime = false;
        //Main.time = Main.dayLength; //54000
        //Main.time = Main.nightLength; //32400
        //Main.time = 1800;
    }
}