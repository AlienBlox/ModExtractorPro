using Microsoft.Xna.Framework.Graphics;
using ModExtractorPro.Abstracts;
using ReLogic.Content;
using Terraria.ModLoader;

namespace ModExtractorPro.ModExtraction.UIItems
{
    /// <summary>
    /// A top bar
    /// </summary>
    public class TopBar : BaseUI
    {
        public ModExtractorUI UI { get; set; }

        public override Asset<Texture2D> Texture => ModContent.Request<Texture2D>("ModExtractorPro/ModExtraction/UIItems/ModExtractorTopBar");

        public override bool DrawBase => true;

        public override void SafeDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture.Value, UI.PosBase, UI.BaseColor);
        }
    }
}