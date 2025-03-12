using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.System.Extraction
{
    public class ExtractorPlr : ModPlayer
    {
        public Mod ConnectedMod => ModLoader.Mods[CurrentMod];

        public int CurrentMod = 0;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ExtractorSystem.SwitchMods.JustPressed)
            {
                if (CurrentMod++ < ModLoader.Mods.GetLength(0))
                {
                    Main.NewText($"The current mod is: {ConnectedMod.Name}");
                }
                else
                {
                    CurrentMod = 0;
                }
            }

            if (ExtractorSystem.SaveMods.JustPressed)
            {
                ConnectedMod.ExtractAssets();
                ConnectedMod.Extract();
            }
        }
    }
}