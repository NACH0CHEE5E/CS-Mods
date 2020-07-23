using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandaros.Settlers.Models;
using Pandaros.Settlers.Items;
using Pandaros.Settlers;
using Recipes;
using Jobs;
using UnityEngine;
using NPC;
using Pandaros.Settlers.Jobs.Roaming;
using Pipliz;
using Shared;
using Chatting;

namespace NACH0.Alchemy
{
    public class AlchemistWorkBench : CSType
    {
        public override string name { get; set; } = Nach0Config.TypePrefix + "AlchemistWorkBench";
        public override string icon { get; set; } = Nach0Config.ModIconFolder + "AlchemistWorkBench.png";
        public override bool? isPlaceable { get; set; } = true;
        public override string onPlaceAudio { get; set; } = "stonePlace";
        public override string onRemoveAudio { get; set; } = "stoneDelete";
        public override bool? isSolid { get; set; } = true;
        public override string sideall { get; set; } = "stonebricks";
        public override List<string> categories { get; set; } = new List<string>()
        {
            "job",
            "Alchemy",
            "NACH0"
        };
    }
    public class AlchemistWorkBenchRecipe : ICSRecipe
    {
        public List<RecipeItem> requires => new List<RecipeItem>()
        {
            { new RecipeItem(Nach0Config.TypePrefix + "AlchemistWorkTable", 3) }
        };

        public List<RecipeResult> results => new List<RecipeResult>()
        {
            { new RecipeResult(Nach0Config.TypePrefix + "AlchemistWorkBench", 1) }
        };

        public CraftPriority defaultPriority => CraftPriority.Low;

        public bool isOptional => true;

        public int defaultLimit => 5;

        public string Job => Nach0Config.BaseJobPrefix + "crafter";

        public string name => Nach0Config.CrafterRecipePrefix + "AlchemistWorkBench";
    }
    public class AlchemistWorkBenchRegister : IRoamingJobObjective
    {
        public string name => "AlchemistWorkBench";
        public float WorkTime => 10f;
        public ItemId ItemIndex => ItemId.GetItemId(Nach0Config.TypePrefix + "AlchemistWorkBench");
        public Dictionary<string, IRoamingJobObjectiveAction> ActionCallbacks { get; } = new Dictionary<string, IRoamingJobObjectiveAction>()
        {
            { AlchemyConstraints.EXPERIMENT, new PerformExperiments() }
        };
        public float WatchArea => 10;
        public string ObjectiveCategory => "toilet";

        public void DoWork(Colony colony, RoamingJobState WorkBenchState)
        {
            if (colony.OwnerIsOnline())
                if (WorkBenchState.GetActionEnergy(AlchemyConstraints.EXPERIMENT) > 0 &&
                    WorkBenchState.NextTimeForWork < Pipliz.Time.SecondsSinceStartDouble)
                {
                    if (TimeCycle.IsDay)
                    {
                        WorkBenchState.SubtractFromActionEnergy(AlchemyConstraints.EXPERIMENT, 0.05f);
                    }

                    WorkBenchState.NextTimeForWork = WorkBenchState.RoamingJobSettings.WorkTime + Pipliz.Time.SecondsSinceStartDouble;


                }
        }
    }
        public class PerformExperiments : IRoamingJobObjectiveAction
        {
            public string name => AlchemyConstraints.EXPERIMENT;

            public float TimeToPreformAction => 10;
            public float ActionEnergyMinForFix => 0f;

        public string AudioKey => GameLoader.NAMESPACE + ".HammerAudio";

            public ItemId ObjectiveLoadEmptyIcon => ItemId.GetItemId(Nach0Config.IndicatorTypePrefix + "AlchemyExperiment");

            public ItemId PreformAction(Colony colony, RoamingJobState state)
            {
                var retval = ItemId.GetItemId(Nach0Config.IndicatorTypePrefix + "AlchemyExperiment");

                if (colony.OwnerIsOnline())
                {
                    if (state.GetActionEnergy(AlchemyConstraints.EXPERIMENT) <= 0f)
                    {
                        var repaired = false;
                        var experimentItems = new List<InventoryItem>();
                        experimentItems.Add(new InventoryItem(ColonyBuiltIn.ItemTypes.GOLDORE.Name, 35));
                        var stockpile = colony.Stockpile;



                        if (stockpile.Contains(experimentItems))
                        {
                            stockpile.TryRemove(experimentItems);
                            repaired = true;
                        }
                        else
                        {
                            foreach (var item in experimentItems)
                                if (!stockpile.Contains(item))
                                {
                                    retval = ItemId.GetItemId(item.Type);
                                    break;
                                }
                        }

                        if (repaired)
                            state.ResetActionToMaxLoad(AlchemyConstraints.EXPERIMENT);
                    }
                }
                return retval;
            }
        }
    [ModLoader.ModManager]
    public class OpenAlchemyUI
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnPlayerClicked, Nach0Config.Name + ".Alchemy.OnPlayerClick")]
        public static void OpenUI(Players.Player player, PlayerClickedData data)
        {
            PlayerClickedData.VoxelHit voxelData = data.GetVoxelHit();
            if (data.ClickType == PlayerClickedData.EClickType.Left && data.HitType == PlayerClickedData.EHitType.Block)
            {
                    if (voxelData.TypeHit == ItemId.GetItemId(Nach0Config.TypePrefix + "AlchemistWorkTable") && voxelData.DistanceToHit == 3f)
                    {
                        Chat.Send(player, "<color=blue>Itemtype Alchemist Work Table has been pressed</color>");
                    }
                
            }
        }
    }
}
