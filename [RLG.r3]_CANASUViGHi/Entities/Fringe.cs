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

namespace RLG.R3_CANASUViGHi.Entities
{
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Contracts;

    /// <summary>
    /// Fringe object.
    /// </summary>
    internal sealed class Fringe : GameObject, IFringe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fringe" /> class.
        /// </summary>
        /// <param name="id">The ID of the Fringe object.</param>
        /// <param name="name">The name of the Fringe object.</param>
        /// <param name="texture">The texture representing the Fringe object.</param>
        /// <param name="flags">Fringe object flags.</param>
        public Fringe(int id, string name, Texture2D texture, Flags flags)
            : base(id, name, flags)
        {
            this.Texture = texture;
        }

        /// <summary>
        /// Gets the Texture of the Terrain.
        /// </summary>
        public Texture2D Texture { get; private set; }
    }
}
