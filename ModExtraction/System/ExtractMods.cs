using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.System
{
    /// <summary>
    /// Extract mods with this
    /// </summary>
    public static partial class ExtractMods
    {
        /// <summary>
        /// Extracts the mod
        /// </summary>
        /// <param name="mod">The connected mod </param>
        public static void Extract(this Mod mod)
        {
            if (Directory.Exists(Main.SavePath + $"\\SavedMods\\{mod.Name}"))
            {
                return;
            }

            if (!Directory.Exists(Main.SavePath + "\\SavedMods"))
            {
                CreateFolders.MakeFolder(Main.SavePath + "\\SavedMods");
            }

            CreateFolders.MakeFolder(mod.Name);

            foreach (string FileName in mod.GetFileNames())
            {
                Stream StreamThing = mod.GetFileStream(FileName);

                if (!Directory.Exists(Main.SavePath + $"\\{mod.Name}\\{StreamThing}"))
                {
                    FileStream FS = new(FileName, FileMode.Open);

                    FS.Dispose();
                }
            }
        }
    }
}