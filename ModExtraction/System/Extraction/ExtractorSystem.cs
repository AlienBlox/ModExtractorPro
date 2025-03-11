using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.System.Extraction
{
    public class ExtractorSystem : ModSystem
    {
        public static ModKeybind SwitchMods { get; private set; }
        public static ModKeybind SaveMods { get; private set; }

        public override void Load()
        {
            SwitchMods = KeybindLoader.RegisterKeybind(Mod, "SwitchMods", Keys.J);
            SaveMods = KeybindLoader.RegisterKeybind(Mod, "SaveMods", Keys.OemPeriod);
        }
    }
}