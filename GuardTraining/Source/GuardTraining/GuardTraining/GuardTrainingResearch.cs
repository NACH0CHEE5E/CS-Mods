using Pandaros.Settlers.ColonyManagement;
using Pandaros.Settlers.Models;
using System.Collections.Generic;
using Pandaros.Settlers.Research;
using Pandaros.Settlers;
using NACH0.Models;
using Science;

namespace NACH0.Research
{
    [ModLoader.ModManager]
    public class Nach0GuardResearch
    {
        public class ImprovedSlingshotResearch : PandaResearch
        {
            public override string name => Nach0ColonyBuiltIn.NpcTypes.SLINGSHOTDAY.Replace(".Day", "");

            public override string IconDirectory => Nach0Config.ModIconFolder;

            public override float BaseValue => 0.05f;

            public override Dictionary<int, List<InventoryItem>> RequiredItems => new Dictionary<int, List<InventoryItem>>()
            {
                {
                    0,
                    new List<InventoryItem>()
                    {
                        new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.SLINGSHOT.Id),
                        new InventoryItem(ColonyBuiltIn.ItemTypes.SLINGBULLET.Id, 5)
                    }
                }
            };
            public override Dictionary<int, List<string>> Dependancies => new Dictionary<int, List<string>>()
            {
                {
                    0,
                    new List<string>()
                    {
                        Nach0ColonyBuiltIn.Research.SLINGSHOT
                    }
                }
            };

            public override void ResearchComplete(object sender, ResearchCompleteEventArgs e)
            {
                SettlerManager.ApplyJobCooldownsToNPCs(e.Manager.Colony);
            }
        }
        public class ImprovedCompoundBowResearch : PandaResearch
        {
            public override string name => Nach0ColonyBuiltIn.NpcTypes.COMPOUNDBOWDAY.Replace(".Day", "");

            public override string IconDirectory => Nach0Config.ModIconFolder;

            public override float BaseValue => 0.05f;

            public override Dictionary<int, List<InventoryItem>> RequiredItems => new Dictionary<int, List<InventoryItem>>()
        {
            {
                0,
                new List<InventoryItem>()
                {
                    new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.COMPOUNDBOW.Id),
                    new InventoryItem(ColonyBuiltIn.ItemTypes.BRONZEARROW.Id, 5)
                }
            }
        };
            public override Dictionary<int, List<string>> Dependancies => new Dictionary<int, List<string>>()
            {
                {
                    0,
                    new List<string>()
                    {
                        Nach0ColonyBuiltIn.Research.COMPOUNDBOW
                    }
                }
            };

            public override void ResearchComplete(object sender, ResearchCompleteEventArgs e)
            {
                SettlerManager.ApplyJobCooldownsToNPCs(e.Manager.Colony);
            }
        }
        public class ImprovedSniperResearch : PandaResearch
        {
            public override string name => Nach0ColonyBuiltIn.NpcTypes.SNIPERDAY.Replace(".Day", "");

            public override string IconDirectory => Nach0Config.ModIconFolder;

            public override float BaseValue => 0.05f;

            public override Dictionary<int, List<InventoryItem>> RequiredItems => new Dictionary<int, List<InventoryItem>>()
        {
            {
                0,
                new List<InventoryItem>()
                {
                    new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.SNIPER.Id),
                    new InventoryItem(ColonyBuiltIn.ItemTypes.LEADBULLET.Id, 5),
                    new InventoryItem(ColonyBuiltIn.ItemTypes.GUNPOWDERPOUCH.Id, 2)
                }
            }
        };
            public override Dictionary<int, List<string>> Dependancies => new Dictionary<int, List<string>>()
            {
                {
                    0,
                    new List<string>()
                    {
                        Nach0ColonyBuiltIn.Research.SNIPER
                    }
                }
            };

            public override void ResearchComplete(object sender, ResearchCompleteEventArgs e)
            {
                SettlerManager.ApplyJobCooldownsToNPCs(e.Manager.Colony);
            }
        }
        public class ImprovedBallistaResearch : PandaResearch
        {
            public override string name => Nach0ColonyBuiltIn.NpcTypes.BALLISTADAY.Replace(".Day", "");

            public override string IconDirectory => Nach0Config.ModIconFolder;

            public override float BaseValue => 0.05f;

            public override Dictionary<int, List<InventoryItem>> RequiredItems => new Dictionary<int, List<InventoryItem>>()
        {
            {
                0,
                new List<InventoryItem>()
                {
                    new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.BALLISTA.Id),
                    new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.BALLISTABOLT.Id, 5)
                }
            }
        };
            public override Dictionary<int, List<string>> Dependancies => new Dictionary<int, List<string>>()
            {
                {
                    0,
                    new List<string>()
                    {
                        Nach0ColonyBuiltIn.Research.BALLISTA
                    }
                }
            };

            public override void ResearchComplete(object sender, ResearchCompleteEventArgs e)
            {
                SettlerManager.ApplyJobCooldownsToNPCs(e.Manager.Colony);
            }
        }
        public class ImprovedSwordGuardResearch : PandaResearch
        {
            public override string name => Nach0ColonyBuiltIn.NpcTypes.SWORDDAY.Replace(".Day", "");

            public override string IconDirectory => Nach0Config.ModIconFolder;

            public override float BaseValue => 0.05f;

            public override Dictionary<int, List<InventoryItem>> RequiredItems => new Dictionary<int, List<InventoryItem>>()
        {
            {
                0,
                new List<InventoryItem>()
                {
                    new InventoryItem(Nach0ColonyBuiltIn.ItemTypes.SWORDSHEATH.Id),
                    new InventoryItem(ColonyBuiltIn.ItemTypes.IRONSWORD.Id, 5)
                }
            }
        };
            public override Dictionary<int, List<string>> Dependancies => new Dictionary<int, List<string>>()
            {
                {
                    0,
                    new List<string>()
                    {
                        Nach0ColonyBuiltIn.Research.SWORDGUARD
                    }
                }
            };

            public override void ResearchComplete(object sender, ResearchCompleteEventArgs e)
            {
                SettlerManager.ApplyJobCooldownsToNPCs(e.Manager.Colony);
            }
        }
    }
}

