using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipliz;

namespace NACH0
{
    [ModLoader.ModManager]
    public class Nach0Config
    {
        public const string Name = "NACH0";
        public const string TypePrefix = Name + ".Types.";
        public const string IndicatorTypePrefix = TypePrefix + "Indicator.";
        public const string ResearchPrefix = Name + ".Research.";
        public const string JobPrefix = Name + ".Jobs.";
        public const string TexturePrefix = Name + ".Textures.";
        public const string JobGuardPrefix = Name + ".Jobs.Guard.";
        public const string ModName = "Mod";
        public const string ModFullName = Name + "." + ModName;
        public const string GamedataFolder = "gamedata";
        public const string ModsFolder = GamedataFolder + "/mods";
        public const string ModFolder = ModsFolder + "/" + Name + "/" + ModName;
        public const string ModGamedataFolder = ModFolder + "/gamedata";
        public const string ModIconFolder = ModGamedataFolder + "/textures/icons/";
        public static bool GuardsMod = true;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterModsLoaded, Name + ".AfterModsLoaded.ModCheck")]
        public void AfterModsLoaded(List<ModLoader.ModDescription> list)
        {

            foreach (var mod in list)
            {
                if (mod.modJSON != null)
                {
                    Log.Write(mod.modJSON.ToString());
                    if (mod.name.ToString() == Name + ".Guards")
                    {
                        GuardsMod = true;
                    }
                }
                
            }
        }
    }
}
