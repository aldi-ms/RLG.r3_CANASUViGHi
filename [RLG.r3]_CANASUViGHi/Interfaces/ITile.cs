using RLG.R3_CANASUViGHi.Framework.FieldOfView;
using RLG.R3_CANASUViGHi.Enums;

namespace RLG.R3_CANASUViGHi.Interfaces
{
    /// <summary>
    /// Interface for the Game Tile.
    /// </summary>
    internal interface ITile : IFovCell
    {
        /// <summary>
        /// Gets or sets the Terrain ID of the Tile.
        /// </summary>
        ITerrain Terrain { get; set; }

        /// <summary>
        /// Gets or sets the Fringe element ID of the Tile.
        /// </summary>
        int Fringe { get; set; }

        /// <summary>
        /// Gets or sets the Item List ID of the Tile.
        /// </summary>
        int ItemList { get; set; }

        /// <summary>
        /// Gets or sets the Actor of the Tile.
        /// </summary>
        IActor Actor { get; set; }

        /// <summary>
        /// Gets the (cumulative from other elements) Tile Flags.
        /// </summary>
        Flags Flags { get; }
    }
}
