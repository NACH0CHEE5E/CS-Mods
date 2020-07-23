using BlockTypes;
using Pipliz.JSON;
using Recipes;
using System.Collections.Generic;
using System.Linq;

namespace Nach0.API.Types
{
    [ModLoader.ModManager]
    public static class AddItemTypes
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, "Nach0.API.AddItem")]
        [ModLoader.ModCallbackDependsOn("pipliz.server.applymoditempatches")]
        public static void AddItem(Dictionary<string, ItemTypesServer.ItemTypeRaw> items)
        {
            var itemName = "Nach0.API.ItemTest";
            var itemNode = new JSONNode();
            var categories = new JSONNode(NodeType.Array);
            categories.AddToArray(new JSONNode("Nach0"));
            itemNode.SetAs("categories", categories);
            itemNode["isPlaceable"] = new JSONNode(false);

            var item = new ItemTypesServer.ItemTypeRaw(itemName, itemNode);
            items.Add(itemName, item);

            /*var copperSwordName = GameLoader.NAMESPACE + ".CopperSword";
            var copperSwordNode = new JSONNode();
            copperSwordNode["icon"] = new JSONNode(GameLoader.ICON_PATH + "CopperSword.png");
            copperSwordNode["isPlaceable"] = new JSONNode(false);

            var categories = new JSONNode(NodeType.Array);
            categories.AddToArray(new JSONNode("weapon"));
            copperSwordNode.SetAs("categories", categories);

            var copperSword = new ItemTypesServer.ItemTypeRaw(copperSwordName, copperSwordNode);
            items.Add(copperSwordName, copperSword);

            WeaponFactory.WeaponLookup.Add(copperSword.ItemIndex, new WeaponMetadata(50f, 50, copperSwordName, copperSword));

            var bronzeSwordName = GameLoader.NAMESPACE + ".BronzeSword";
            var bronzeSwordNode = new JSONNode();
            bronzeSwordNode["icon"] = new JSONNode(GameLoader.ICON_PATH + "BronzeSword.png");
            bronzeSwordNode["isPlaceable"] = new JSONNode(false);

            bronzeSwordNode.SetAs("categories", categories);

            var bronzeSword = new ItemTypesServer.ItemTypeRaw(bronzeSwordName, bronzeSwordNode);
            items.Add(bronzeSwordName, bronzeSword);

            WeaponFactory.WeaponLookup.Add(bronzeSword.ItemIndex, new WeaponMetadata(100f, 75, bronzeSwordName, bronzeSword));

            var IronSwordName = GameLoader.NAMESPACE + ".IronSword";
            var IronSwordNode = new JSONNode();
            IronSwordNode["icon"] = new JSONNode(GameLoader.ICON_PATH + "IronSword.png");
            IronSwordNode["isPlaceable"] = new JSONNode(false);

            IronSwordNode.SetAs("categories", categories);

            var IronSword = new ItemTypesServer.ItemTypeRaw(IronSwordName, IronSwordNode);
            items.Add(IronSwordName, IronSword);

            WeaponFactory.WeaponLookup.Add(IronSword.ItemIndex, new WeaponMetadata(250f, 100, IronSwordName, IronSword));

            var steelSwordName = GameLoader.NAMESPACE + ".SteelSword";
            var steelSwordNode = new JSONNode();
            steelSwordNode["icon"] = new JSONNode(GameLoader.ICON_PATH + "SteelSword.png");
            steelSwordNode["isPlaceable"] = new JSONNode(false);

            steelSwordNode.SetAs("categories", categories);

            var steelSword = new ItemTypesServer.ItemTypeRaw(steelSwordName, steelSwordNode);
            items.Add(steelSwordName, steelSword);

            WeaponFactory.WeaponLookup.Add(steelSword.ItemIndex, new WeaponMetadata(500f, 150, steelSwordName, steelSword));*/
        }
    }
}
