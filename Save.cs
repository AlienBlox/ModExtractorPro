using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ID;
using Terraria;
using System.IO;
using Terraria.ModLoader;
using ModExtractorPro.ModExtraction.System.Utility;

namespace ModExtractorPro
{
    public static partial class Save
    {
        /// <summary>
        /// Saves this asset as an png
        /// </summary>
        /// <param name="asset">The asset to save</param>
        public static void SaveAsPng(this Asset<Texture2D> asset, Mod mod)
        {
            asset.Name.GetPositionReverse('\\', out int pos);

            string save = Main.SavePath + $"\\SavedMods\\{mod.Name}\\{asset.Name.Replace('/', '\\').Remove(pos)}";

            if (!Directory.Exists(save))
            {
                Directory.CreateDirectory(save);
            }

            if (!File.Exists(Main.SavePath + $"\\SavedMods\\{mod.Name}\\{asset.Name.Replace('/', '\\')}"))
            {
                try
                {
                    Stream Stream = File.Create(Main.SavePath + $"\\AlienBloxSaves\\SavedImages\\File-{save}.png");

                    asset.Value.SaveAsPng(Stream, asset.Width(), asset.Height());
                    Stream.Dispose();
                }
                catch
                {
                    
                }
            }
        }
    }
}