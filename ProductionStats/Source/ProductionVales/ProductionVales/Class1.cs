﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Chatting;
using Shared;
using NetworkUI;
using NetworkUI.Items;
using System.Linq;

namespace ProductionValues
{
    [ModLoader.ModManager]
    class ProductionValues
    {
        public const string MODNAMESPACE = "NACH0.ProductionStats.";
        //public static string version = "0.3.0";
        //public static string oldVersion = "";

        /*public static string GAMEDATA_FOLDER = @"";
        public static string GAME_SAVES = @"";
        public static string GAME_SAVEFILE = @"";
        public static string GAME_ROOT = @"";
        public static string MOD_FOLDER = @"";

        public static string FILE_NAME = "ProductionStats.json";*/
        public static string FILE_PATH;

        public static Dictionary<int, Dictionary<string, int[]>> ProductionItems = new Dictionary<int, Dictionary<string, int[]>>();
        //public static Dictionary<string, int> Settings = new Dictionary<string, int>();
        static bool WasDay = false;
        //static int day = 0;

        /*[ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, MODNAMESPACE + "OnAssemblyLoaded")]
        public static void OnAssemblyLoaded(string path)
        {
            
        }*/

        /*[ModLoader.ModCallback(ModLoader.EModCallbackType.AfterSelectedWorld, MODNAMESPACE + "AfterSelectedWorld")]
        public static void AfterSelectedWorld()
        {
            //get current mod version
            string file = "./gamedata/mods/NACH0/ProductionStats/modInfo.json";
            string version = File.ReadLines(file).Skip(3).Take(1).First();
            version = version.Replace("    \"version\": \"", "");
            version = version.Remove(5);

            //get old version
            string oldVersion = "0.0.0";
            file = "./gamedata/savegames/" + ServerManager.WorldName + "/ProductionStats.Version";
            if (File.Exists(file))
            {
                oldVersion = File.ReadAllText(file);
            }
            else
            {
                File.WriteAllText(file, version);
            }

            //read production stats file
            FILE_PATH = "./gamedata/savegames/" + ServerManager.WorldName + "/ProductionStats.json";
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

            //if mod version is less than 0.3.0
            if (Int32.Parse(oldVersion.Substring(2, 1)) < 3)
            {
                Dictionary<int, Dictionary<string, Dictionary<int, int>>> oldProductionItems = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, Dictionary<int, int>>>>(FILE_CONTENTS);
                foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                {
                    
                    if (oldProductionItems.ContainsKey(colony.ColonyID))
                    {
                        ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                        foreach (var type in oldProductionItems[colony.ColonyID])
                        {
                            if (!ProductionItems.ContainsKey(colony.ColonyID))
                            {
                                ProductionItems[colony.ColonyID] = new Dictionary<string, int[]>();
                            }
                            if (!ProductionItems[colony.ColonyID].ContainsKey(type.Key))
                            {
                                ProductionItems[colony.ColonyID][type.Key] = new int[10];
                                foreach (var value in oldProductionItems[colony.ColonyID][type.Key])
                                {
                                    ProductionItems[colony.ColonyID][type.Key][value.Key % 10] = value.Value;
                                }
                            }
                        }
                    }
                }
                string foodgenfile = "./gamedata/savegames/" + ServerManager.WorldName + "/FoodGen.json";
                if (File.Exists(foodgenfile))
                {
                    Dictionary<string, Dictionary<string, int>> food = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(File.ReadAllText(foodgenfile));
                    foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                    {
                        if (food.ContainsKey(colony.ColonyID.ToString()))
                        {
                            if (!ProductionItems.ContainsKey(colony.ColonyID))
                            {
                                ProductionItems[colony.ColonyID] = new Dictionary<string, int[]>();
                            }
                            if (!ProductionItems[colony.ColonyID].ContainsKey("_calories"))
                            {
                                ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                                foreach (var value in food[colony.ColonyID.ToString()])
                                {
                                    ProductionItems[colony.ColonyID]["_calories"][Int32.Parse(value.Key) % 10] = value.Value;
                                }
                            }
                        }
                    }

                }
                return;
            }

            //else
            ProductionItems = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, int[]>>>(FILE_CONTENTS);
        }*/

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterWorldLoad, MODNAMESPACE + "AfterWorldLoad")]
        public static void AfterWorldLoad()
        {
            if (TimeCycle.IsDay)
            {
                WasDay = true;
            }

            //get current mod version
            string file = "./gamedata/mods/NACH0/ProductionStats/modInfo.json";
            string version = File.ReadLines(file).Skip(3).Take(1).First();
            version = version.Replace("    \"version\": \"", "");
            version = version.Remove(5);

            //get old version
            string oldVersion = "0.0.0";
            file = "./gamedata/savegames/" + ServerManager.WorldName + "/ProductionStats.Version";
            if (File.Exists(file))
            {
                oldVersion = File.ReadAllText(file);
            }
            File.WriteAllText(file, version);

            //read production stats file
            FILE_PATH = "./gamedata/savegames/" + ServerManager.WorldName + "/ProductionStats.json";
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

            //if mod version was less than 0.3.0
            if (Int32.Parse(oldVersion.Substring(2, 1)) < 3)
            {
                Dictionary<int, Dictionary<string, Dictionary<int, int>>> oldProductionItems = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, Dictionary<int, int>>>>(FILE_CONTENTS);
                foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                {
                    if (!ProductionItems.ContainsKey(colony.ColonyID))
                    {
                        ProductionItems[colony.ColonyID] = new Dictionary<string, int[]>();
                    }
                    if (oldProductionItems.ContainsKey(colony.ColonyID))
                    {
                        foreach (var type in oldProductionItems[colony.ColonyID])
                        {
                            if (!ProductionItems[colony.ColonyID].ContainsKey(type.Key))
                            {
                                ProductionItems[colony.ColonyID][type.Key] = new int[10];
                                foreach (var value in oldProductionItems[colony.ColonyID][type.Key])
                                {
                                    ProductionItems[colony.ColonyID][type.Key][value.Key % 10] = value.Value;
                                }
                            }
                        }
                    }
                }
                string foodgenfile = "./gamedata/savegames/" + ServerManager.WorldName + "/FoodGen.json";
                if (File.Exists(foodgenfile))
                {
                    Dictionary<int, Dictionary<int, int>> food = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<int, int>>>(File.ReadAllText(foodgenfile));
                    foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                    {
                        if (food.ContainsKey(colony.ColonyID))
                        {
                            if (!ProductionItems.ContainsKey(colony.ColonyID))
                            {
                                ProductionItems[colony.ColonyID] = new Dictionary<string, int[]>();
                            }
                            if (!ProductionItems[colony.ColonyID].ContainsKey("_calories"))
                            {
                                ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                                foreach (var value in food[colony.ColonyID])
                                {
                                    ProductionItems[colony.ColonyID]["_calories"][value.Key % 10] = value.Value;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                    {
                        ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                    }
                }
                return;
            }

            //else
            ProductionItems = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, int[]>>>(FILE_CONTENTS);
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnUpdate, MODNAMESPACE + "OnUpdate")]
        public static void OnUpdate()
        {
            if (!WasDay && TimeCycle.IsDay)
            {
                WasDay = true;
                //int day = Pipliz.Math.RoundToInt(System.Math.Floor(TimeCycle.TotalHours / 24));
                return;
            }
            else if (WasDay && !TimeCycle.IsDay)
            {
                int day = Pipliz.Math.RoundToInt(System.Math.Floor(TimeCycle.TotalHours / 24));
                foreach (Colony colony in ServerManager.ColonyTracker.ColoniesByID.Values)
                {
                    if (!ProductionItems.ContainsKey(colony.ColonyID))
                    {
                        ProductionItems[colony.ColonyID] = new Dictionary<string, int[]>();
                    }
                    if (!ProductionItems[colony.ColonyID].ContainsKey("_calories"))
                    {
                        ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                    }
                    foreach (var type in ProductionItems[colony.ColonyID])
                    {
                        if (type.Key.Equals("_calories"))
                        {
                            if (ProductionItems[colony.ColonyID]["_calories"].Equals(null))
                            {
                                ProductionItems[colony.ColonyID]["_calories"] = new int[10];
                            }
                            ProductionItems[colony.ColonyID]["_calories"][day % 10] = Pipliz.Math.RoundToInt(colony.Stockpile.TotalFood);
                        }
                        else
                        {
                            if (ProductionItems[colony.ColonyID][type.Key].Equals(null))
                            {
                                ProductionItems[colony.ColonyID][type.Key] = new int[10];
                            }
                            ProductionItems[colony.ColonyID][type.Key][day % 10] = colony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0);
                        }
                        //ProductionItems[colony.ColonyID][type.Key].Add(day, colony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0));
                        /*if (ProductionItems[colony.ColonyID][type.Key].ContainsKey(day - 11))
                        {
                            ProductionItems[colony.ColonyID][type.Key].Remove(day - 11);
                        }*/

                    }
                }
                WasDay = false;
            }
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAutoSaveWorld, MODNAMESPACE + "OnAutoSaveWorld")]
        public static void OnAutoSaveWorld()
        {
            var fileContnets = JsonConvert.SerializeObject(ProductionItems, Formatting.Indented);
            File.WriteAllText(FILE_PATH, fileContnets);
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnSaveWorldMisc, MODNAMESPACE + "OnSaveWorldMisc")]
        public static void OnSaveWorldMisc(JObject j)
        {
            var fileContnets = JsonConvert.SerializeObject(ProductionItems, Formatting.Indented);
            File.WriteAllText(FILE_PATH, fileContnets);
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerClicked, MODNAMESPACE + "OnPlayerClick")]
        public static void OnPlayerClicked(Players.Player player, PlayerClickedData data)
        {
            if (data.TypeSelected == ItemTypes.GetType("NACH0.Types.ProductionStats").ItemIndex)
            {
                if (data.ClickType == PlayerClickedData.EClickType.Left)
                {
                    SendUI(player);
                }
            }
        }
        public static void SendUI(Players.Player player)
        {
            int day = Pipliz.Math.RoundToInt(System.Math.Floor(TimeCycle.TotalHours / 24));
            NetworkMenu ProductionUI = new NetworkMenu();
            ProductionUI.Identifier = "ProductionUI";
            ProductionUI.LocalStorage.SetAs("header", "Production Stats");
            ProductionUI.Width = 800;
            ProductionUI.Height = 400;

            Label itemLabel = new Label("Item: ");
            Label changeFromYesterdayLabel = new Label("Change From Yesterday: ");
            Label changeFrom5DaysAgoLabel = new Label("Average Change per day over 5 days: ");
            ButtonCallback addButton = new ButtonCallback(MODNAMESPACE + "AddType", new LabelData("Add", UnityEngine.Color.black, UnityEngine.TextAnchor.MiddleCenter));
            List<(IItem, int)> horizontalRowItems = new List<(IItem, int)>();

            horizontalRowItems.Add((itemLabel, 64));
            horizontalRowItems.Add((changeFromYesterdayLabel, 200));
            horizontalRowItems.Add((changeFrom5DaysAgoLabel, 300));
            horizontalRowItems.Add((addButton, 75));
            HorizontalRow horizontalRow = new HorizontalRow(horizontalRowItems);
            ProductionUI.Items.Add(horizontalRow);

            if (!player.ActiveColony.Equals(null) && ProductionItems.ContainsKey(player.ActiveColony.ColonyID))
            {
                if (ProductionItems[player.ActiveColony.ColonyID].ContainsKey("_calories"))
                {
                    Label calories = new Label("Calories:");
                    Label yesterday = new Label("No Data");
                    Label fivedays = new Label("No Data");
                    if (!ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 1) % 10].Equals(null))
                    {
                        int amount = (player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType("_calories").ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 1) % 10]) * 2000;
                        if (amount >= 10000 || amount <= -10000)
                        {
                            amount = amount / 1000;
                            yesterday = new Label(String.Format("{0:n0}", amount) + "K  Calories");
                        }
                        else
                        {
                            yesterday = new Label(String.Format("{0:n0}", amount) + "  Calories");
                        }
                    }
                    if (!ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 5) % 10].Equals(null))
                    {
                        int currentfromyesterday = player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType("_calories").ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 1) % 10];
                        int yesterdayfrom2days = ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 1) % 10] - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 2) % 10];
                        int _2daysfrom3days = ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 2) % 10] - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 3) % 10];
                        int _3daysfrom4days = ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 3) % 10] - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 4) % 10];
                        int _4daysfrom5days = ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 4) % 10] - ProductionItems[player.ActiveColony.ColonyID]["_calories"][(day - 5) % 10];
                        int amount = ((currentfromyesterday + yesterdayfrom2days + _2daysfrom3days + _3daysfrom4days + _4daysfrom5days) / 5) * 2000;
                        if (amount >= 10000 || amount <= -10000)
                        {
                            amount = amount / 1000;
                            fivedays = new Label(String.Format("{0:n0}", amount) + "K  Calories");
                        }
                        else
                        {
                            fivedays = new Label(String.Format("{0:n0}", amount) + " Calories");
                        }
                    }

                    horizontalRowItems = new List<(IItem, int)>();

                    horizontalRowItems.Add((calories, 64));
                    horizontalRowItems.Add((yesterday, 200));
                    horizontalRowItems.Add((fivedays, 300));
                    horizontalRow = new HorizontalRow(horizontalRowItems);
                    ProductionUI.Items.Add(horizontalRow);
                }
                foreach (var type in ProductionItems[player.ActiveColony.ColonyID])
                {
                    if (!type.Key.Equals("_calories"))
                    {
                        ItemIcon icon = new ItemIcon(type.Key);
                        Label yesterday = new Label("No Data");
                        Label fivedays = new Label("No Data");
                        ButtonCallback removeButton = new ButtonCallback(MODNAMESPACE + "RemoveType." + type.Key, new LabelData("Remove", UnityEngine.Color.black, UnityEngine.TextAnchor.MiddleCenter));
                        if (!ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 1) % 10].Equals(null))
                        {
                            int amount = (player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 1) % 10]) * 2000;
                            if (amount >= 10000 || amount <= -10000)
                            {
                                amount = amount / 1000;
                                yesterday = new Label(String.Format("{0:n0}", amount) + "K " + type.Key);
                            }
                            else
                            {
                                yesterday = new Label(String.Format("{0:n0}", amount) + " " + type.Key);
                            }
                        }
                        if (!ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 5) % 10].Equals(null))
                        {
                            //fivedays = new Label(((player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 5).ToString()]) / 5).ToString());
                            //int amount = (player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 5).ToString()]) / 5;
                            int currentfromyesterday = player.ActiveColony.Stockpile.Items.GetValueOrDefault(ItemTypes.GetType(type.Key).ItemIndex, 0) - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 1) % 10];
                            int yesterdayfrom2days = ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 1) % 10] - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 2) % 10];
                            int _2daysfrom3days = ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 2) % 10] - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 3) % 10];
                            int _3daysfrom4days = ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 3) % 10] - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 4) % 10];
                            int _4daysfrom5days = ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 4) % 10] - ProductionItems[player.ActiveColony.ColonyID][type.Key][(day - 5) % 10];
                            int amount = ((currentfromyesterday + yesterdayfrom2days + _2daysfrom3days + _3daysfrom4days + _4daysfrom5days) / 5) * 2000;
                            if (amount >= 10000 || amount <= -10000)
                            {
                                amount = amount / 1000;
                                fivedays = new Label(String.Format("{0:n0}", amount) + "K " + type.Key);
                            }
                            else
                            {
                                fivedays = new Label(String.Format("{0:n0}", amount) + " " + type.Key);
                            }
                        }

                        horizontalRowItems = new List<(IItem, int)>();

                        horizontalRowItems.Add((icon, 64));
                        horizontalRowItems.Add((yesterday, 200));
                        horizontalRowItems.Add((fivedays, 300));
                        horizontalRowItems.Add((removeButton, 75));
                        horizontalRow = new HorizontalRow(horizontalRowItems);
                        ProductionUI.Items.Add(horizontalRow);
                    }
                }
            }

            NetworkMenuManager.SendServerPopup(player, ProductionUI);
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerPushedNetworkUIButton, MODNAMESPACE + "onButtonPushed")]
        public static void onButtonPushed(ButtonPressCallbackData data)
        {
            if (!data.ButtonIdentifier.StartsWith(MODNAMESPACE))
            {
                return;
            }
            data.ButtonIdentifier = data.ButtonIdentifier.Remove(0, 22);
            if (data.ButtonIdentifier.StartsWith("RemoveType"))
            {
                data.ButtonIdentifier = data.ButtonIdentifier.Remove(0, 11);
                if (ProductionItems[data.Player.ActiveColony.ColonyID].ContainsKey(data.ButtonIdentifier))
                {
                    ProductionItems[data.Player.ActiveColony.ColonyID].Remove(data.ButtonIdentifier);
                    Chat.Send(data.Player, "<color=yellow>" + data.ButtonIdentifier + " has been removed</color>");
                    SendUI(data.Player);
                    return;
                }
                Chat.Send(data.Player, "<color=yellow>" + data.ButtonIdentifier + " was not being recorded, could not remove</color>");
            }
            else if (data.ButtonIdentifier.StartsWith("AddType"))
            {
                string typeName = ItemTypes.GetType(data.Player.Inventory.Items[0].Type).Name;
                if (!ProductionItems[data.Player.ActiveColony.ColonyID].ContainsKey(typeName))
                {
                    ProductionItems[data.Player.ActiveColony.ColonyID][typeName] = new int[10];
                    Chat.Send(data.Player, "<color=yellow>Added " + typeName + " to production chain will take 5 ingame days to see all data</color>");
                    SendUI(data.Player);
                    return;
                }
                Chat.Send(data.Player, "<color=yellow>" + typeName + " is already being recorded</color>");
            }
        }

        [ChatCommandAutoLoader]
        public class AddTypesCommand : IChatCommand
        {
            public bool TryDoCommand(Players.Player player, string chat, List<string> splits)
            {
                if (player.Equals(null))
                {
                    return false;
                }
                chat.ToLower();
                if (chat.StartsWith("/production"))
                {
                    string typeName = ItemTypes.GetType(player.Inventory.Items[0].Type).Name;
                    chat = chat.Remove(0, 12);
                    if (!ProductionItems.ContainsKey(player.ActiveColony.ColonyID))
                    {
                        ProductionItems[player.ActiveColony.ColonyID] = new Dictionary<string, int[]>();
                    }
                    if (chat.StartsWith("add"))
                    {
                        if (!ProductionItems[player.ActiveColony.ColonyID].ContainsKey(typeName))
                        {
                            ProductionItems[player.ActiveColony.ColonyID][typeName] = new int[10];
                            Chat.Send(player, "<color=yellow>Added " + typeName + " to production chain will take 5 ingame days to see all data</color>");
                            return true;
                        }
                        Chat.Send(player, "<color=yellow>" + typeName + " is already being recorded</color>");
                        return true;
                    }
                    else if (chat.StartsWith("remove"))
                    {
                        if (ProductionItems[player.ActiveColony.ColonyID].ContainsKey(typeName))
                        {
                            ProductionItems[player.ActiveColony.ColonyID].Remove(typeName);
                            Chat.Send(player, "<color=yellow>" + typeName + " has been removed</color>");
                            return true;
                        }
                        Chat.Send(player, "<color=yellow>" + typeName + " was not being recorded, could not remove</color>");
                        return true;
                    }
                }
                return false;
            }

        }
    }
}
