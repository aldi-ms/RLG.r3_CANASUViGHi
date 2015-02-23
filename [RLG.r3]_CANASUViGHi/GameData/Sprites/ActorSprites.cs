using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RLG.R3_CANASUViGHi.GameData.Sprites
{
    internal sealed class ActorSprites
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorSprites" /> class.
        /// Loads all actor sprites.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        public ActorSprites(ContentManager content)
        {
            this.HumanM = content.Load<Texture2D>("tiles/player/base/human_m");
        }

        /// <summary>
        /// Gets actor sprite human_m
        /// </summary>
        public Texture2D HumanM { get; private set; }
    }
}
