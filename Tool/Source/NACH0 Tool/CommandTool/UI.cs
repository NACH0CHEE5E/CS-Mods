using Pipliz;

using Chatting;
using NetworkUI;
using NetworkUI.Items;
using Science;
using System;
using Shared;

using System.Collections.Generic;
using System.Linq;
using Pipliz.JSON;
using System.IO;
using UnityEngine;

namespace NACH0.CommandTool
{
    //open ui with command
    [ChatCommandAutoLoader]
    public class Command : IChatCommand
    {
        public bool TryDoCommand(Players.Player player, string chat, List<string> splits)
        {
            if (player == null)
                return false;

            if (!chat.Equals("?nach0tool"))
                return false;

            //Sends the UI to the player
            SendCommandUI.SendUI(player);

            return true;
        }
    }

    //draws ui
    [ModLoader.ModManager]
    public class SendCommandUI
    {
        static readonly localization.LocalizationHelper _localizationHelper = new localization.LocalizationHelper("CommandTool");
        public static void SendUI(Players.Player player)
        {
            NetworkMenu commandUI = new NetworkMenu();
            commandUI.Identifier = "CommandToolUI";
            commandUI.LocalStorage.SetAs("header", _localizationHelper.LocalizeOrDefault("CommandTool", player));
            commandUI.Width = 500;
            commandUI.Height = 600;

            
            ButtonCallback GuardsButton = new ButtonCallback(Nach0Config.Name + ".UIButton.Guards", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Guards", player), Color.black));

            
            Label Guardslabel = new Label(_localizationHelper.LocalizeOrDefault("Label.Guards", player));
            ButtonCallback BackButton = new ButtonCallback(Nach0Config.Name + ".UIButton.Back", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Back", player), Color.black));
            List<(IItem, int)> GuardsHeaderHorizontalItems = new List<(IItem, int)>();

            GuardsHeaderHorizontalItems.Add((Guardslabel, 150));
            GuardsHeaderHorizontalItems.Add((BackButton, 75));

            HorizontalRow GuardsHeaderHorizontalRow = new HorizontalRow(GuardsHeaderHorizontalItems);

            Label slingshotlabel = new Label(_localizationHelper.LocalizeOrDefault("Label.Slingshot", player));
            ButtonCallback SlingshotButtonNight = new ButtonCallback(Nach0Config.Name + ".UIButton.SlingShot.Night", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Night", player), Color.black));
            ButtonCallback SlingshotButtonDay = new ButtonCallback(Nach0Config.Name + ".UIButton.SlingShot.Day", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Day", player), Color.black));
            List<(IItem, int)> SlingshotHorizontalItems = new List<(IItem, int)>();

            SlingshotHorizontalItems.Add((slingshotlabel, 150));
            SlingshotHorizontalItems.Add((SlingshotButtonNight, 75));
            SlingshotHorizontalItems.Add((SlingshotButtonDay, 75));

            HorizontalRow SlingshotHorizontalRow = new HorizontalRow(SlingshotHorizontalItems);
            

            //CompoundBow
            Label compoundBowlabel = new Label(_localizationHelper.LocalizeOrDefault("Label.CompoundBow", player));
            ButtonCallback compoundBowButtonNight = new ButtonCallback(Nach0Config.Name + ".UIButton.CompoundBow.Night", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Night", player), Color.black));
            ButtonCallback compoundBowButtonDay = new ButtonCallback(Nach0Config.Name + ".UIButton.CompoundBow.Day", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Day", player), Color.black));
            List<(IItem, int)> compoundBowHorizontalItems = new List<(IItem, int)>();

            compoundBowHorizontalItems.Add((compoundBowlabel, 150));
            compoundBowHorizontalItems.Add((compoundBowButtonNight, 75));
            compoundBowHorizontalItems.Add((compoundBowButtonDay, 75));

            HorizontalRow compoundBowHorizontalRow = new HorizontalRow(compoundBowHorizontalItems);
            

            //Sword
            Label swordlabel = new Label(_localizationHelper.LocalizeOrDefault("Label.ShortSword", player));
            ButtonCallback swordButtonNight = new ButtonCallback(Nach0Config.Name + ".UIButton.Sword.Night", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Night", player), Color.black));
            ButtonCallback swordButtonDay = new ButtonCallback(Nach0Config.Name + ".UIButton.Sword.Day", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Day", player), Color.black));
            List<(IItem, int)> swordHorizontalItems = new List<(IItem, int)>();

            swordHorizontalItems.Add((swordlabel, 150));
            swordHorizontalItems.Add((swordButtonNight, 75));
            swordHorizontalItems.Add((swordButtonDay, 75));

            HorizontalRow swordHorizontalRow = new HorizontalRow(swordHorizontalItems);
            

            //Sniper
            Label sniperlabel = new Label(_localizationHelper.LocalizeOrDefault("Label.Sniper", player));
            ButtonCallback sniperButtonNight = new ButtonCallback(Nach0Config.Name + ".UIButton.Sniper.Night", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Night", player), Color.black));
            ButtonCallback sniperButtonDay = new ButtonCallback(Nach0Config.Name + ".UIButton.Sniper.Day", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Day", player), Color.black));
            List<(IItem, int)> sniperHorizontalItems = new List<(IItem, int)>();

            sniperHorizontalItems.Add((sniperlabel, 150));
            sniperHorizontalItems.Add((sniperButtonNight, 75));
            sniperHorizontalItems.Add((sniperButtonDay, 75));

            HorizontalRow sniperHorizontalRow = new HorizontalRow(sniperHorizontalItems);
            

            //Ballista
            Label ballistalabel = new Label(_localizationHelper.LocalizeOrDefault("Label.Ballista", player));
            ButtonCallback ballistaButtonNight = new ButtonCallback(Nach0Config.Name + ".UIButton.Ballista.Night", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Night", player), Color.black));
            ButtonCallback ballistaButtonDay = new ButtonCallback(Nach0Config.Name + ".UIButton.Ballista.Day", new LabelData(_localizationHelper.LocalizeOrDefault("Button.Day", player), Color.black));
            List<(IItem, int)> ballistaHorizontalItems = new List<(IItem, int)>();

            ballistaHorizontalItems.Add((ballistalabel, 150));
            ballistaHorizontalItems.Add((ballistaButtonNight, 75));
            ballistaHorizontalItems.Add((ballistaButtonDay, 75));

            HorizontalRow ballistaHorizontalRow = new HorizontalRow(ballistaHorizontalItems);

            if (commandUIInteraction.item_placer_option_dict.ContainsKey(player))
            {
                if (commandUIInteraction.item_placer_option_dict[player].Equals("Guards"))
                {
                    commandUI.Items.Add(GuardsHeaderHorizontalRow);
                    if (player == null && player.ConnectionState != Players.EConnectionState.Connected || player.ActiveColony == null || player.ActiveColony.ScienceData == null)
                        return;

                    Science.ScienceKey SlingShotScienceKey = new Science.ScienceKey(Nach0Config.ResearchPrefix + "Slingshot");
                    Science.ScienceKey CompoundBowScienceKey = new Science.ScienceKey(Nach0Config.ResearchPrefix + "CompoundBow");
                    Science.ScienceKey SwordScienceKey = new Science.ScienceKey(Nach0Config.ResearchPrefix + "SwordGuard");
                    Science.ScienceKey SniperScienceKey = new Science.ScienceKey(Nach0Config.ResearchPrefix + "Sniper");
                    Science.ScienceKey BallistaScienceKey = new Science.ScienceKey(Nach0Config.ResearchPrefix + "Ballista");

                    if (SlingShotScienceKey.IsCompleted(player.ActiveColony.ScienceData))
                        commandUI.Items.Add(SlingshotHorizontalRow);
                    if (CompoundBowScienceKey.IsCompleted(player.ActiveColony.ScienceData))
                        commandUI.Items.Add(compoundBowHorizontalRow);
                    if (SwordScienceKey.IsCompleted(player.ActiveColony.ScienceData))
                        commandUI.Items.Add(swordHorizontalRow);
                    if (SniperScienceKey.IsCompleted(player.ActiveColony.ScienceData))
                        commandUI.Items.Add(sniperHorizontalRow);
                    if (BallistaScienceKey.IsCompleted(player.ActiveColony.ScienceData))
                        commandUI.Items.Add(ballistaHorizontalRow);
                } else
                {
                    if (Nach0Config.GuardsMod)
                    {
                        commandUI.Items.Add(GuardsButton);
                        commandUI.Items.Add(new EmptySpace(5));
                    }
                }
            } else
            {
                if (Nach0Config.GuardsMod)
                {
                    commandUI.Items.Add(GuardsButton);
                    commandUI.Items.Add(new EmptySpace(5));
                }
                
            }
            commandUI.Items.Add(new EmptySpace(35));

            //sends ui
            NetworkMenuManager.SendServerPopup(player, commandUI);
        }
    }

    [ModLoader.ModManager]
    public static class commandUIInteraction
    {
        public static Dictionary<Players.Player, string> item_placer_dict = new Dictionary<Players.Player, string>();
        public static Dictionary<Players.Player, string> item_placer_option_dict = new Dictionary<Players.Player, string>();

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerPushedNetworkUIButton, Nach0Config.Name + ".UIButton.OnPlayerPushedNetworkUIButton")]
        public static void OnPlayerPushedNetworkUIButton(ButtonPressCallbackData data)
        {
            string itemPrefix = "NACH0.Types.";
            string guard = ".Guard";
            string night = guard + ".Nightx+";
            string day = guard + ".Dayx+";
            if (data.ButtonIdentifier.StartsWith(Nach0Config.Name + ".UIButton."))
            {
                switch (data.ButtonIdentifier)
                {
                    case Nach0Config.Name + ".UIButton.Guards":
                        item_placer_option_dict[data.Player] = "Guards";
                        SendCommandUI.SendUI(data.Player);
                        item_placer_option_dict[data.Player] = "";
                        return;
                    case Nach0Config.Name + ".UIButton.Back":
                        item_placer_option_dict[data.Player] = "";
                        SendCommandUI.SendUI(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.SlingShot.Night":
                        item_placer_dict[data.Player] = itemPrefix + "Slingshot" + night;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.SlingShot.Day":
                        item_placer_dict[data.Player] = itemPrefix + "Slingshot" + day;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.CompoundBow.Night":
                        item_placer_dict[data.Player] = itemPrefix + "CompoundBow" + night;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.CompoundBow.Day":
                        item_placer_dict[data.Player] = itemPrefix + "CompoundBow" + day;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Sword.Night":
                        item_placer_dict[data.Player] = itemPrefix + "Sword" + night;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Sword.Day":
                        item_placer_dict[data.Player] = itemPrefix + "Sword" + day;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Sniper.Night":
                        item_placer_dict[data.Player] = itemPrefix + "Sniper" + night;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Sniper.Day":
                        item_placer_dict[data.Player] = itemPrefix + "Sniper" + day;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Ballista.Night":
                        item_placer_dict[data.Player] = itemPrefix + "Ballista" + night;
                        AfterItemTypeChanged(data.Player);
                        return;
                    case Nach0Config.Name + ".UIButton.Ballista.Day":
                        item_placer_dict[data.Player] = itemPrefix + "Ballista" + day;
                        AfterItemTypeChanged(data.Player);
                        return;
                }
            }
            
        }
        public static void AfterItemTypeChanged(Players.Player player)
        {
            //Chat.Send(player, "<color=blue>Item_Placer Type set to: " + commandUIInteraction.item_placer_dict[player] + "</color>");
        }
    }
}
