using Pipliz.JSON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace Nach0.API
{
    [ModLoader.ModManager]
    static class ModSettings
    {
        static string Location = @"";

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, "Nach0.API.GetLocation")]
        static void GetLocation(string path)
        {
            Location = Path.GetDirectoryName(path).Replace("\\", "/");
        }
    }
}
