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

namespace RLG.R3_CANASUViGHi.Models
{
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Interfaces;

    /// <summary>
    /// Terrain object.
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
        /// <param name="movementCost">The cost for moving on this Terrain.</param>
        public Terrain(int id, string name, Texture2D texture, Flags flags, int movementCost)
            : base(id, name, flags)
        {
            this.Texture = texture;
            this.MovementCost = movementCost;
        }
                
        /// <summary>
        /// Gets the Texture of the Terrain.
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Gets or sets the cost for moving to a Tile with this Terrain.
        /// </summary>
        /// <remarks>Set to 0 for blocked terrain.</remarks>
        public int MovementCost { get; set; }
    }
}
