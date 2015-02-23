using Microsoft.Xna.Framework.Graphics;
using RLG.R3_CANASUViGHi.Enums;
using RLG.R3_CANASUViGHi.Interfaces;

namespace RLG.R3_CANASUViGHi.Models
{
    /// <summary>
    /// Terrain information.
    /// </summary>
    internal sealed class Terrain : GameObject, ITerrain
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Terrain" /> class.
        /// </summary>
        /// <param name="id">The ID of the terrain.</param>
        /// <param name="name">The name of the terrain.</param>
        /// <param name="texture">The texture representing the terrain.</param>
        /// <param name="flags">Terrain flags.</param>
        public Terrain(int id, string name, Texture2D texture, Flags flags)
            : base(id, name, flags)
        {
            this.Texture = texture;
        }
                
        /// <summary>
        /// Gets the Texture2D of the Terrain.
        /// </summary>
        public Texture2D Texture { get; private set; }
    }
}
