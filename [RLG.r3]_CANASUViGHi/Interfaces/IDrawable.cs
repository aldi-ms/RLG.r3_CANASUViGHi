using Microsoft.Xna.Framework.Graphics;

namespace RLG.R3_CANASUViGHi.Interfaces
{
    /// <summary>
    /// Contains the Texture property, ensuring that this object
    /// holds a Texture2D to be drawn on the screen.
    /// </summary>
    internal interface IDrawableObject : IGameObject
    {
        /// <summary>
        /// Gets the Texture2D of the Game Object.
        /// </summary>
        Texture2D Texture { get; }
    }
}
