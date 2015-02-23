using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RLG.R3_CANASUViGHi.GameData.Sprites;

namespace RLG.R3_CANASUViGHi.GameData
{
    /// <summary>
    /// Static class, keeping all loaded sprites / textures.
    /// </summary>
    internal static class Sprite
    {
        /// <summary>
        /// Keeps the size of the sprites (TileSize x TileSize) in pixels.
        /// <para>Ex. 32x32.</para>
        /// </summary>
        internal const int TileSize = 32;

        /// <summary>
        /// Gets loaded Actor sprites.
        /// </summary>
        internal static ActorSprites Player { get; private set; }

        /// <summary>
        /// Gets loaded Floor sprites.
        /// </summary>
        internal static FloorSprites Floor { get; private set; }

        /// <summary>
        /// Gets loaded wall sprites.
        /// </summary>
        internal static WallSprites Wall { get; private set; }

        /// <summary>
        /// Static initializer for all sprites / textures.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        internal static void LoadSprites(ContentManager content)
        {
            if (Player == null)
            {
                Player = new ActorSprites(content);
            }

            if (Floor == null)
            {
                Floor = new FloorSprites(content);
            }

            if (Wall == null)
            {
                Wall = new WallSprites(content);
            }
        }
    }
}
