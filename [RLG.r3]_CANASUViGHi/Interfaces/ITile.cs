/* *
* Canas Uvighi, a RogueLike Game / RPG project.
* Copyright (C) 2015 Aleksandar Dimitrov (screen name SCiENiDE)
* 
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* */

namespace RLG.R3_CANASUViGHi.Interfaces
{
    using RLG.R3_CANASUViGHi.Framework.FieldOfView;
    using RLG.R3_CANASUViGHi.Enums;

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
