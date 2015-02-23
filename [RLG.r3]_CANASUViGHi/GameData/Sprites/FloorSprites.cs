using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RLG.R3_CANASUViGHi.GameData.Sprites
{
    /// <summary>
    /// Load and keep all textures in properly named properties.
    /// </summary>
    internal sealed class FloorSprites
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorSprites" /> class.
        /// Loads all floor sprites.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        public FloorSprites(ContentManager content)
        {
            this.PebbleBrown0 = content.Load<Texture2D>("tiles/dungeon/floor/pebble_brown0");
        }

        /// <summary>
        /// Gets floor sprite pebble_brown0.
        /// </summary>
        public Texture2D PebbleBrown0 { get; private set; }
    }
}
