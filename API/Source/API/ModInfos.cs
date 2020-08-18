using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nach0.API
{
    [ModLoader.ModManager]
    public static class ModInfos
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterModsLoaded, "Nach0.API.ReadModInfos")]
        public static void ReadModInfos(Dictionary<string, ItemTypesServer.ItemTypeRaw> items)
        {

        }
    }
}
