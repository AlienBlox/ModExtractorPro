using Microsoft.Xna.Framework.Graphics;
using ModExtractorPro.Abstracts;
using ReLogic.Content;
using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.UIItems
{
    public class ModExtractorUI : BaseUI
    {
        public Asset<Texture2D> TexturePrimary { get; set; }

        public override Asset<Texture2D> Texture => ModContent.Request<Texture2D>("ModExtractorPro/ModExtraction/UIItems/ModExtractorUIBase");

        public override bool DrawBase => true;

        public override void SafeDraw(SpriteBatch spriteBatch)
        {
            TexturePrimary = ModContent.Request<Texture2D>("ModExtractorPro/ModExtraction/UIItems/ModExtractorMain");

            spriteBatch.Draw(TexturePrimary.Value, PosBase, BaseColor);
        }
    }
}