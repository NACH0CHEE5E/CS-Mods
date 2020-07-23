using System.Collections.Generic;
using System.IO;
using Pipliz;

namespace NoNight
{
    [ModLoader.ModManager]
    class Class1
    {
        public const string MOD_VERSION = "0.1.0";

        public const string NAME = "NACH0";
        public const string MODNAME = "FoodGen";
        public const string MODNAMESPACE = NAME + "." + MODNAME + ".";

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnUpdate, MODNAMESPACE + "OnUpdate")]
        public static void OnUpdate()
        {
            if (!TimeCycle.IsDay)
            {
                TimeCycle.AddTime(TimeCycle.GameTimeSpan.FromGameHours(12));
            }
        }
    }
}
