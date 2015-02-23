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
    using RLG.R3_CANASUViGHi.Models;

    /// <summary>
    /// Interface for Game Terrain.
    /// </summary>
    internal interface ITerrain : IDrawableObject
    {
        /// <summary>
        /// Gets or sets the cost for moving to a Tile with this Terrain.
        /// </summary>
        /// <remarks>Set to 0 for blocked terrain.</remarks>
        int MovementCost { get; set; }
    }
}
