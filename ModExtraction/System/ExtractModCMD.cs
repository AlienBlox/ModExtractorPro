using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.System
{
    public class ExtractModCMD : ModCommand
    {
        public override string Command => "!Extract";

        public override CommandType Type => CommandType.Chat;

        public override string Usage => "!Extract (modname)";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            foreach (Mod M in ModLoader.Mods)
            {
                if (input.Contains(M.Name))
                {
                    M.Extract();
                }
            }
        }
    }
}