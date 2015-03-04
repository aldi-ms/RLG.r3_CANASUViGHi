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

namespace RLG.R3_CANASUViGHi.Contracts
{
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;

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
