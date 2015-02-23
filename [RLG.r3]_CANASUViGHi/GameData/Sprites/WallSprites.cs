using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RLG.R3_CANASUViGHi.GameData.Sprites
{
    /// <summary>
    /// Load and keep all wall sprites / textures.
    /// </summary>
    internal sealed class WallSprites
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WallSprites" /> class.
        /// Loads all wall sprites.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        public WallSprites(ContentManager content)
        {
            this.BrickBrown0 = content.Load<Texture2D>("tiles/dungeon/wall/brick_brown0");
        }

        /// <summary>
        /// Gets wall sprite brick_brown0.
        /// </summary>
        public Texture2D BrickBrown0 { get; private set; }
    }
}
