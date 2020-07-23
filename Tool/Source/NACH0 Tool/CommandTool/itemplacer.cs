using NetworkUI;
using Pipliz;
using Shared;
using System.Collections.Generic;
using UnityEngine;
using Chatting;
using NACH0.Models;

namespace NACH0.CommandTool
{
    [ModLoader.ModManager]
    public class ItemPlace
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerClicked, Nach0Config.Name + ".CommandTool.OnPlayerClick")]
        public static void PlaceItem(Players.Player player, PlayerClickedData data)
        {
            if (data.TypeSelected == ItemTypes.GetType(Nach0ColonyBuiltIn.ItemTypes.COMMANDTOOL).ItemIndex)
            {
                PlayerClickedData.VoxelHit voxelData = data.GetVoxelHit();
                if (data.ClickType == PlayerClickedData.EClickType.Left)
                {
                    SendCommandUI.SendUI(player);
                }
                else if (data.ClickType == PlayerClickedData.EClickType.Right)
                {
                    if (PlayerClickedData.EHitType.Block == data.HitType && voxelData.SideHit == VoxelSide.yPlus)
                    {
                            if (commandUIInteraction.item_placer_dict.ContainsKey(player))
                            {
                                ServerManager.TryChangeBlock(voxelData.PositionBuild, ItemTypes.GetType(commandUIInteraction.item_placer_dict[player]).ItemIndex, player);
                            }
                    }
                }
            }
        }
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnSendAreaHighlights, Nach0Config.Name + ".CommandTool.OnSendAreaHighlights")]
        private static void OnSendAreaHighlights(Players.Player goal, List<AreaJobTracker.AreaHighlight> list, List<ushort> showWhileHoldingTypes)
        {
            showWhileHoldingTypes.Add(ItemTypes.GetType(Nach0ColonyBuiltIn.ItemTypes.COMMANDTOOL).ItemIndex);
        }
        /*public class Nach0CommandTool : CSType
        {
            public static string NAME = Nach0Config.TypePrefix + "CommandTool";
            public override string name => NAME;
            public override string icon => Nach0Config.ModIconFolder + "CommandTool.png";
            public override bool? isPlaceable => false;
            public override int? maxStackSize => 1;
            public override List<string> categories { get; set; } = new List<string>()
            {
                "essential",
                "aaa"
            };
            public override StaticItem StaticItemSettings => new StaticItem() { Name = Nach0Config.TypePrefix + "CommandTool" };
        }*/
    }
}
