using ModExtractorPro.ModExtraction.System.Utility;
using System.IO;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

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
            try
            {
                if (Directory.Exists(Main.SavePath + $"\\SavedMods\\{mod.Name}"))
                {
                    return;
                }
                else
                {
                    Directory.CreateDirectory(Main.SavePath + $"\\SavedMods\\{mod.Name}");
                }

                Directory.CreateDirectory(Main.SavePath + $"\\SavedMods\\{mod.Name}");

                if (!Directory.Exists(Main.SavePath + "\\SavedMods"))
                {
                    CreateFolders.MakeFolder(Main.SavePath + "\\SavedMods");
                }

                CreateFolders.MakeFolder(mod.Name);

                foreach (string FileName in mod.GetFileNames())
                {
                    byte[] FS = mod.GetFileBytes(FileName);

                    FileName.GetPositionReverse('\\', out int P);

                    string SaveMain = Main.SavePath + $"\\{mod.Name}";

                    string Save = SaveMain + $"\\{FileName.Replace("/", "\\").Remove(P)}";

                    if (!Directory.Exists(SaveMain))
                    {
                        if (!Directory.Exists(Save))
                        {
                            Directory.CreateDirectory(Main.SavePath + FileName.ToFileP());
                        }

                        if (FileName.GetExt() == ".rawimg")
                        {
                            FileName.GetPositionReverse('.', out int pos);

                            FileStream Streamer = File.Create(Save + FileName[..pos] + ".png");

                            Streamer.Write(FS, 0, FS.Length);

                            Streamer.Dispose();
                        }
                        else
                        {
                            FileStream Streamer = File.Create(Save + FileName);

                            Streamer.Write(FS, 0, FS.Length);

                            Streamer.Dispose();
                        }
                    }
                }

                File.Create(Main.SavePath + $"\\SavedMods\\{mod.Name}\\BuildInfo.txt").Dispose();

                StreamWriter Writer = new(Main.SavePath + $"\\SavedMods\\{mod.Name}\\BuildInfo.txt", false, Encoding.UTF8);

                Writer.WriteLine("Decompiled mod with AlienBlox's Mod Extractor Pro");
                Writer.WriteLine("Make sure to support this project by going to https://www.youtube.com/channel/UCpu_V3nxWViuAOHAeGlkyvQ/");

                Writer.Dispose();
            }
            catch
            {
                Main.NewText("Can't save mod");
            }
        }
    }
}