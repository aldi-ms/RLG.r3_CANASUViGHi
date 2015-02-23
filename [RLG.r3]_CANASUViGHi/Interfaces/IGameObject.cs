using Microsoft.Xna.Framework.Graphics;
using RLG.R3_CANASUViGHi.Enums;

namespace RLG.R3_CANASUViGHi.Interfaces
{
    /// <summary>
    /// Base interface for all drawable game elements.
    /// </summary>
    internal interface IGameObject
    {
        /// <summary>
        /// Gets the ID of the Game Object.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets the Name of the Game Object.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the Flags of the Game Object.
        /// </summary>
        Flags Flags { get; set; }
    }
}
