using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace AndrosCommands.Common;

public class AndroCommandSystem : ModSystem
{
    private static double _frozenTime;
    private static bool _timeIsFrozen;

    public static bool TimeIsFrozen
    {
        get => _timeIsFrozen;
        set
        {
            _timeIsFrozen = value;

            if (_timeIsFrozen)
            {
                _frozenTime = Main.time;
            }
        }
    }

    public override void PostUpdateInput()
    {
        if (_timeIsFrozen)
        {
            Main.time = _frozenTime;
            NetMessage.SendData(MessageID.WorldData, -1, -1, (NetworkText)null, 0, 0f, 0f, 0f, 0, 0, 0);
        }
    }
}