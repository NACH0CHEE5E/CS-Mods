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
        [ModLoader.ModCallback(ModLoader.EModCallbackType.AddItemTypes, "Nach0.API.AddItems")]
        [ModLoader.ModCallbackDependsOn("pipliz.server.applymoditempatches")]
        public static void AddItem(Dictionary<string, ItemTypesServer.ItemTypeRaw> items)
        {
            ModSettings.Location
            foreach 

            var item = new ItemTypesServer.ItemTypeRaw(itemName, itemNode);
            items.Add(itemName, item);
        }
    }
}
