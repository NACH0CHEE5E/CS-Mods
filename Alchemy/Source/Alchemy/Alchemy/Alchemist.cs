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

namespace NACH0.Alchemy
{
    public class Alchemist
    {
        public static Pandaros.Settlers.localization.LocalizationHelper LocalizationHelper { get; private set; } = new Pandaros.Settlers.localization.LocalizationHelper(Nach0Config.Name, "Alchemy");
        public static bool experiment = false;
    }
    public class AlchemistTable : CSType
    {
        public override string name => Nach0Config.TypePrefix + "AlchemistTable";
        public override string icon => Nach0Config.ModIconFolder + "AlchemistTable.png";
        public override string onPlaceAudio => "woodPlace";
        public override string onRemoveAudio => "woodDeleteLight";
        public override string sideall => "planks";
        public override List<string> categories => new List<string>() { "job", "alchemy", "NACH0" }; // whatever you want really
    }
    public class AlchemistWorkTableRecipe : ICSRecipe
    {
        public string name => Nach0Config.CrafterRecipePrefix + "AlchemistTable";

        public List<RecipeItem> requires => new List<RecipeItem>()
        {
            { new RecipeItem(ColonyBuiltIn.ItemTypes.WORKBENCH.Name, 3) },
            { new RecipeItem(ColonyBuiltIn.ItemTypes.GOLDORE.Name, 15) }
        };

        public List<RecipeResult> results => new List<RecipeResult>()
        {
            { new RecipeResult(Nach0Config.TypePrefix + "AlchemistTable", 1) }
        };

        public CraftPriority defaultPriority => CraftPriority.Low;
        public bool isOptional => false;
        public int defaultLimit => 2;
        public string Job => Nach0Config.BaseJobPrefix + "crafter";
    }

    public class AlchemistSettings : IBlockJobSettings
    {
        static NPCType _Settings;
        public virtual float NPCShopGameHourMinimum { get { return TimeCycle.Settings.SleepTimeEnd; } }
        public virtual float NPCShopGameHourMaximum { get { return TimeCycle.Settings.SleepTimeStart; } }

        static AlchemistSettings()
        {
            NPCType.AddSettings(new NPCTypeStandardSettings
            {
                keyName = Nach0Config.JobPrefix + "Alchemist",
                printName = "Alchemist",
                maskColor1 = new Color32(242, 132, 29, 255),
                type = NPCTypeID.GetNextID(),
                inventoryCapacity = 1f
            });

            _Settings = NPCType.GetByKeyNameOrDefault(Nach0Config.JobPrefix + "Alchemist");
        }

        public virtual ItemTypes.ItemType[] BlockTypes => new[]
        {
            ItemTypes.GetType(Nach0Config.TypePrefix + "AlchemistTable")
        };

        public NPCType NPCType => _Settings;

        public virtual InventoryItem RecruitmentItem => new InventoryItem("coppertools");

        public virtual bool ToSleep => !TimeCycle.IsDay;

        public Pipliz.Vector3Int GetJobLocation(BlockJobInstance instance)
        {
            if (instance is RoamingJob roamingJob)
                return roamingJob.OriginalPosition;

            return Pipliz.Vector3Int.invalidPos;
        }

        public void OnGoalChanged(BlockJobInstance instance, NPCBase.NPCGoal goalOld, NPCBase.NPCGoal goalNew)
        {

        }

        public void OnNPCAtJob(BlockJobInstance instance, ref NPCBase.NPCState state)
        {
            instance.OnNPCAtJob(ref state);
        }

        public void OnNPCAtStockpile(BlockJobInstance instance, ref NPCBase.NPCState state)
        {

        }
    }
    public class AlchemistRoaming : RoamingJob
    {
        public static string JOB_NAME = Nach0Config.JobPrefix + "Alchemist";
        public static string JOB_ITEM_KEY = Nach0Config.TypePrefix + "AlchemistTable";
        public static string JOB_RECIPE = Nach0Config.CrafterRecipePrefix + "AlchemistTable";

        public AlchemistRoaming(IBlockJobSettings settings, Pipliz.Vector3Int position, ItemTypes.ItemType type, ByteReader reader) :
            base(settings, position, type, reader)
        {
        }

        public AlchemistRoaming(IBlockJobSettings settings, Pipliz.Vector3Int position, ItemTypes.ItemType type, Colony colony) :
            base(settings, position, type, colony)
        {
        }


        public override List<string> ObjectiveCategories => new List<string>() { "Alchemy" };
        public override string JobItemKey => JOB_ITEM_KEY;
        public override List<ItemId> OkStatus => new List<ItemId>
            {
                ItemId.GetItemId(GameLoader.NAMESPACE + ".Waiting"),
                ItemId.GetItemId(Nach0Config.IndicatorTypePrefix + "AlchemyExperiment")
            };
    }

    public class AlchemyExperimentIcon : CSType
    {
        public override string name => Nach0Config.IndicatorTypePrefix + "AlchemyExperiment";
        public override string icon => Nach0Config.ModIconFolder + "AlchemyExperiment.png";
    }

    [ModLoader.ModManager]
    public class AlchemistModEntries
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesDefined, Nach0Config.ModFullName + ".Alchemist")]
        [ModLoader.ModCallbackProvidesFor("create_savemanager")]
        public static void AfterDefiningNPCTypes()
        {
            ServerManager.BlockEntityCallbacks.RegisterEntityManager(
                new BlockJobManager<AlchemistRoaming>(
                    new AlchemistSettings(),
                    (setting, pos, type, bytedata) => new AlchemistRoaming(setting, pos, type, bytedata),
                    (setting, pos, type, colony) => new AlchemistRoaming(setting, pos, type, colony)
                )
            );
        }
    }
}
