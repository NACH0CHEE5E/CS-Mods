using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Chatting;
using Shared;
using NetworkUI;
using NetworkUI.Items;
using System.Linq;

namespace CS_Electricty
{
    [ModLoader.ModManager]
    class Electricity
    {
        public const string MODNAMESPACE = "NACH0.Electricty.";
        public static string FILE_PATH;
        public static Dictionary<int, int> PowerAmounts = new Dictionary<int, int>();

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterWorldLoad, MODNAMESPACE + "AfterWorldLoad")]
        public static void AfterWorldLoad()
        {
            //read electricty file
            FILE_PATH = "./gamedata/savegames/" + ServerManager.WorldName + "/" + MODNAMESPACE + "json";
            if (!File.Exists(FILE_PATH))
            {
                File.Create(FILE_PATH);
            }
            var FILE_CONTENTS = File.ReadAllText(FILE_PATH);

            //will terminate if empty
            if (FILE_CONTENTS.Equals(""))
            {
                return;
            }

            PowerAmounts = JsonConvert.DeserializeObject<Dictionary<int, int>>(FILE_CONTENTS);
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAutoSaveWorld, MODNAMESPACE + "OnAutoSaveWorld")]
        public static void OnAutoSaveWorld()
        {
            var fileContnets = JsonConvert.SerializeObject(PowerAmounts, Formatting.Indented);
            File.WriteAllText(FILE_PATH, fileContnets);
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnSaveWorldMisc, MODNAMESPACE + "OnSaveWorldMisc")]
        public static void OnSaveWorldMisc(JObject j)
        {
            var fileContnets = JsonConvert.SerializeObject(PowerAmounts, Formatting.Indented);
            File.WriteAllText(FILE_PATH, fileContnets);
        }
    }

}
