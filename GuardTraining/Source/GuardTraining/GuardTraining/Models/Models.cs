

using Pandaros.Settlers.Models;

namespace NACH0.Models
{
    public static class Nach0ColonyBuiltIn
    {
        private const string TYPE = Nach0Config.TypePrefix;
        private const string INDICATOR = Nach0Config.IndicatorTypePrefix;
        private const string JOB = Nach0Config.JobPrefix;
        private const string GUARD = Nach0Config.JobGuardPrefix;
        private const string RESEARCH = Nach0Config.ResearchPrefix;
        public static class Research
        {
            public const string FLETCHER = RESEARCH + "Fletcher";
            public const string COPPERWORKER = RESEARCH + "CopperWorker";
            public const string TOOLCRAFTER = RESEARCH + "ToolCrafter";
            public const string BRICKMAKER = RESEARCH + "BrickMaker";
            public const string FREEZER = RESEARCH + "Freezer";
            public const string PAINTMIXER = RESEARCH + "PaintMixer";
            public const string PAINTERSTABLE = RESEARCH + "PaintersTable";
            public const string IRONANVIL = RESEARCH + "IronAnvil";
            public const string STEELANVIL = RESEARCH + "SteelAnvil";
            public const string BASICSTONEMASON = RESEARCH + "BasicStoneMason";
            public const string SLINGSHOT = RESEARCH + "Slingshot";
            public const string BALLISTA = RESEARCH + "Ballista";
            public const string COMPOUNDBOW = RESEARCH + "CompoundBow";
            public const string SNIPER = RESEARCH + "Sniper";
            public const string SWORDGUARD = RESEARCH + "SwordGuard";
            public const string ALCHEMISTBENCH = RESEARCH + "AlchemistBench";
            public const string ALCHEMYEXPERIMENT1 = RESEARCH + "AlchemyExperiment.1";
            public const string ALCHEMYEXPERIMENT2 = RESEARCH + "AlchemyExperiment.2";
            public const string ALCHEMYEXPERIMENT3 = RESEARCH + "AlchemyExperiment.3";
            public const string ALCHEMYEXPERIMENT4 = RESEARCH + "AlchemyExperiment.4";
            public const string ALCHEMYEXPERIMENT5 = RESEARCH + "AlchemyExperiment.5";
            public const string ALCHEMYEXPERIMENT6 = RESEARCH + "AlchemyExperiment.6";
            public const string ALCHEMYEXPERIMENT7 = RESEARCH + "AlchemyExperiment.7";
            public const string ALCHEMYEXPERIMENT8 = RESEARCH + "AlchemyExperiment.8";
            public const string ALCHEMYEXPERIMENT9 = RESEARCH + "AlchemyExperiment.9";
            public const string ALCHEMYEXPERIMENT10 = RESEARCH + "AlchemyExperiment.10";
            public const string ALCHEMYEXPERIMENT11 = RESEARCH + "AlchemyExperiment.11";
            public const string ALCHEMYEXPERIMENT12 = RESEARCH + "AlchemyExperiment.12";
            public const string ALCHEMYEXPERIMENT13 = RESEARCH + "AlchemyExperiment.13";
            public const string ALCHEMYEXPERIMENT14 = RESEARCH + "AlchemyExperiment.14";
            public const string ALCHEMYEXPERIMENT15 = RESEARCH + "AlchemyExperiment.15";
            public const string ALCHEMYEXPERIMENT16 = RESEARCH + "AlchemyExperiment.16";
            public const string ALCHEMYEXPERIMENT17 = RESEARCH + "AlchemyExperiment.17";
            public const string ALCHEMYEXPERIMENT18 = RESEARCH + "AlchemyExperiment.18";
            public const string ALCHEMYEXPERIMENT19 = RESEARCH + "AlchemyExperiment.19";
            public const string ALCHEMYEXPERIMENT20 = RESEARCH + "AlchemyExperiment.20";
        }
        public static class NpcTypes
        {
            public const string COPPERWORKER = JOB + "CopperWorker";
            public const string BRICKMAKER = JOB + "BrickMaker";
            public const string FLETCHER = JOB + "Fletcher";
            public const string TOOLCRAFTER = JOB + "ToolCrafter";
            public const string ORGANICTRADER = JOB + "OrganicTrader";
            public const string FREEZER = JOB + "Freezer";
            public const string PAINTMIXER = JOB + "PaintMixer";
            public const string PAINTER = JOB + "Painter";
            public const string BASICSTONEMASON = JOB + "BasicStoneMason";
            public const string IRONANVILWORKER = JOB + "IronAnvilWorker";
            public const string STEELANVILWORKER = JOB + "SteelAnvilWorker";
            public const string SLINGSHOTDAY = GUARD + "Slingshot.Day";
            public const string BALLISTADAY = GUARD + "Ballista.Day";
            public const string COMPOUNDBOWDAY = GUARD + "CompoundBow.Day";
            public const string SNIPERDAY = GUARD + "Sniper.Day";
            public const string SWORDDAY = GUARD + "Sword.Day";
            public const string SLINGSHOTNIGHT = GUARD + "Slingshot.Night";
            public const string BALLISTANIGHT = GUARD + "Ballista.Night";
            public const string COMPOUNDBOWNIGHT = GUARD + "CompoundBow.Night";
            public const string SNIPERNIGHT = GUARD + "Sniper.Night";
            public const string SWORDNIGHT = GUARD + "Sword.Night";
            public const string ALCHEMIST = JOB + "Jobs.Alchemist";
        }
        public static class ItemTypes
        {
            public static readonly ItemId PAINTMAGENTA = ItemId.GetItemId(TYPE + "MagentaPaint");
            public static readonly ItemId DYEMAGENTA = ItemId.GetItemId(TYPE + "MagentaDye");
            public static readonly ItemId PAINTWHITE = ItemId.GetItemId(TYPE + "WhitePaint");
            public static readonly ItemId ICE = ItemId.GetItemId(TYPE + "Ice1");
            public static readonly ItemId SLINGSHOT = ItemId.GetItemId(TYPE + "Slingshot");
            public static readonly ItemId COMPOUNDBOW = ItemId.GetItemId(TYPE + "CompoundBow");
            public static readonly ItemId BALLISTABOLT = ItemId.GetItemId(TYPE + "BallistaBolt");
            public static readonly ItemId BALLISTA = ItemId.GetItemId(TYPE + "Ballista");
            public static readonly ItemId IRONARMOUR = ItemId.GetItemId(TYPE + "IronArmour");
            public static readonly ItemId SWORDSHEATH = ItemId.GetItemId(TYPE + "SwordSheath");
            public static readonly ItemId SNIPER = ItemId.GetItemId(TYPE + "Sniper");
            public static readonly ItemId ITEMPLACER = ItemId.GetItemId(TYPE + "ItemPlacer");
            public static readonly ItemId COMMANDTOOL = ItemId.GetItemId(TYPE + "CommandTool");
            public static readonly ItemId TOILETHOLE = ItemId.GetItemId(TYPE + "ToiletHole");
            public static readonly ItemId TOILET = ItemId.GetItemId(TYPE + "PorcelainToilet");
            public static readonly ItemId TOILETCLEANINDICATOR = ItemId.GetItemId(INDICATOR + "ToiletClean");
            public static readonly ItemId DANCER = ItemId.GetItemId(TYPE + "DancerBlock");
            public static readonly ItemId DANCERPLATFORM = ItemId.GetItemId(TYPE + "DancerPlatform");
        }
    }
}