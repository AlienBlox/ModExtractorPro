using ModExtractorPro.ModExtraction.System.Utility;
using System.IO;
using System.Text;
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
            else
            {
                Directory.CreateDirectory(Main.SavePath + $"\\SavedMods\\{mod.Name}");
            }

            if (!Directory.Exists(Main.SavePath + "\\SavedMods"))
            {
                CreateFolders.MakeFolder(Main.SavePath + "\\SavedMods");
            }

            CreateFolders.MakeFolder(mod.Name);

            foreach (string FileName in mod.GetFileNames())
            {
                try
                {
                    Stream StreamThing = mod.GetFileStream(FileName);

                    string Save = Main.SavePath + $"\\{mod.Name}\\{StreamThing}";

                    if (!Directory.Exists(Save))
                    {
                        Stream FS = mod.GetFileStream(FileName);

                        if (!Directory.Exists(Save + FileName.ToFileP()))
                        {
                            Directory.CreateDirectory(Main.SavePath + FileName.ToFileP());
                        }

                        if (FileName.GetExt() == ".rawimg")
                        {
                            FileName.GetPositionReverse('.', out int pos);

                            FileStream Streamer = File.Create(Save + FileName[..pos] + ".png");

                            FS.Position = 0;
                            FS.CopyTo(Streamer);

                            Streamer.Dispose();
                            FS.Dispose();
                        }
                        else
                        {
                            FileStream Streamer = File.Create(Save + FileName);

                            FS.Position = 0;
                            FS.CopyTo(Streamer);

                            Streamer.Dispose();
                            FS.Dispose();
                        }
                    }
                }
                catch
                {

                }
            }

            File.Create(Main.SavePath + $"\\SavedMods\\{mod.Name}\\BuildInfo.txt");

            StreamWriter Writer = new(Main.SavePath + $"\\SavedMods\\{mod.Name}\\BuildInfo.txt", false, Encoding.UTF8);

            Writer.WriteLine("Decompiled mod with AlienBlox's Mod Extractor Pro");
            Writer.WriteLine("Make sure to support this project by going to https://www.youtube.com/channel/UCpu_V3nxWViuAOHAeGlkyvQ/");

            Writer.Dispose();
        }
    }
}