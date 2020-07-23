using Newtonsoft.Json;
using Pipliz;
using Pipliz.JSON;
using Recipes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Chatting;
using UnityEngine;

namespace FoodGen
{
    [ModLoader.ModManager]
    class Class1
    {
        public const string MOD_VERSION = "0.1.0";

        public const string NAME = "NACH0";
        public const string MODNAME = "FoodGen";
        public const string MODNAMESPACE = NAME + "." + MODNAME + ".";

        public static string GAMEDATA_FOLDER = @"";
        public static string GAME_SAVES = @"";
        public static string GAME_SAVEFILE = @"";
        public static string GAME_ROOT = @"";
        public static string MOD_FOLDER = @"gamedata/mods/NACH0/Decor";
        public static string MOD_MESH_PATH = "./meshes";
        public static string MOD_ICON_PATH = "./textures/icons";
        public static string MOD_CUSTOM_TEXTURE_PATH = "./textures/custom";

        public static string FILE_NAME = "FoodGen.json";
        public static string FILE_PATH = @"";

        public static Dictionary<string, Dictionary<string, int>> FoodValues { get; private set; }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, MODNAMESPACE + "OnAssemblyLoaded")]
        public static void OnAssemblyLoaded(string path)
        {
            MOD_FOLDER = Path.GetDirectoryName(path) + "/";

            GAME_ROOT = path.Substring(0, path.IndexOf("gamedata")).Replace("\\", "/") + "/";
            GAMEDATA_FOLDER = path.Substring(0, path.IndexOf("gamedata") + "gamedata".Length).Replace("\\", "/") + "/";
            GAME_SAVES = GAMEDATA_FOLDER + "savegames/";
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterSelectedWorld, MODNAMESPACE + "AfterSelectedWorld")]
        public static void AfterSelectedWorld()
        {
            GAME_SAVEFILE = GAME_SAVES + ServerManager.WorldName + "/";
            FILE_PATH = GAME_SAVEFILE + FILE_NAME;

        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterWorldLoad, MODNAMESPACE + "AfterWorldLoad")]
        public static void AfterWorldLoad()
        {
            if (!File.Exists(FILE_PATH))
            {
                File.Create(FILE_PATH);
            }
            var FILE_CONTENTS = File.ReadAllText(FILE_PATH);
            FoodValues = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(FILE_CONTENTS);
        }
        /*[ModLoader.ModCallback(ModLoader.EModCallbackType.OnLoadingColony, MODNAMESPACE + "OnLoadingColony")]
        public static void OnLoadingColony2(Colony colony)
        {
            if (!FoodValues.ContainsKey(colony.ColonyID.ToString()))
            {
                FoodValues.Add(colony.ColonyID.ToString(), null);
            }
        }*/
        /*[ModLoader.ModCallback(ModLoader.EModCallbackType.OnLoadingColony, MODNAMESPACE + "OnLoadingColony")]
        public static void OnLoadingColony(Colony colony, JSONNode n)
        {
            if (!FoodValues.ContainsKey(colony.ColonyID.ToString()))
            {
                FoodValues.Add(colony.ColonyID.ToString(), null);
            }
            if (n.TryGetChild(MODNAMESPACE + "FoodValues", out var stateNode))
            {
            }
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnCreatedColony, MODNAMESPACE + "OnCreatedColony")]
        public static void OnCreatedColony()
        {
            
        }*/
        
    }
}
