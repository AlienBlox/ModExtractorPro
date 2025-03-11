using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.UI;

namespace ModExtractorPro.Abstracts
{
    /// <summary>
    /// Base UI for this mod
    /// </summary>
    public abstract class BaseUI : UIElement
    {
        /// <summary>
        /// The texture of this BaseUI
        /// </summary>
        public virtual Asset<Texture2D> Texture { get; set; }
        /// <summary>
        /// The size of the connected texture
        /// </summary>
        public Vector2 UISize => new(Texture.Width(), Texture.Height());
        /// <summary>
        /// The base position of this UI
        /// </summary>
        public virtual Vector2 PosBase { get; set; }
        /// <summary>
        /// The color of this UI
        /// </summary>
        public virtual Color BaseColor { get; set; } = Color.White;
        /// <summary>
        /// Is this UI enabled?
        /// </summary>
        public virtual bool Enabled { get; set; } = false;
        /// <summary>
        /// Should this UI be drawn by default (True by default)
        /// </summary>
        public virtual bool DrawBase { get; set; } = true;

        /// <summary>
        /// Just OnInitialize() but with memory safety
        /// </summary>
        public virtual void SafeOnInitalize()
        {

        }

        public sealed override void OnInitialize()
        {
            SafeOnInitalize();

            PosBase = new(Main.screenWidth / 2 - UISize.X / 2, Main.screenHeight / 2 - UISize.Y / 2);
        }

        /// <summary>
        /// Just Draw() but with memory safety
        /// </summary>
        /// <param name="spriteBatch">The connected <c>SpriteBatch</c></param>
        public virtual void SafeDraw(SpriteBatch spriteBatch)
        {
            
        }

        public sealed override void Draw(SpriteBatch spriteBatch)
        {
            if (!Enabled)
            {
                return;
            }

            SafeDraw(spriteBatch);
            spriteBatch.Draw(Texture.Value, PosBase, BaseColor);
        }
    }
}