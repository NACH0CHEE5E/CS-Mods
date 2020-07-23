using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nach0.API
{
    [ModLoader.ModManager]
    public static class Locations
    {
        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, "Nach0.API.AddLocation" )]
        public static void AddLocation(string path)
        {
            LocationStorage.
        }
    }
}
