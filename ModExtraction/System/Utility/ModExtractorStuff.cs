using System.IO;
using Terraria.ID;
using Terraria.ModLoader;

#warning Broken code here
namespace ModExtractorPro.ModExtraction.System.Utility
{
    public class ModExtractorStuff : ModSystem
    {
        public override bool HijackGetData(ref byte messageType, ref BinaryReader reader, int playerNumber)
        {
            if (messageType == MessageID.ChatText)
            {
                string S = reader.ReadString();

                if (S.Contains("!Extract"))
                {
                    foreach (Mod M in ModLoader.Mods)
                    {
                        if (S.Contains(M.Name))
                        {
                            M.Extract();
                        }
                    }
                }
            }

            return base.HijackGetData(ref messageType, ref reader, playerNumber);
        }
    }
}