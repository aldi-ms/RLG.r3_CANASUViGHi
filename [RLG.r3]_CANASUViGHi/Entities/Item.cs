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
    using RLG.R3_CANASUViGHi.Contracts;
    using RLG.R3_CANASUViGHi.Enums;

    /// <summary>
    /// Base game Item class.
    /// </summary>
    internal class Item : GameObject, IItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="id">Item ID.</param>
        /// <param name="name">Item name.</param>
        /// <param name="flags">Item flags if any.</param>
        /// <param name="texture">Item icon texture.</param>
        public Item(int id, string name, Flags flags, Texture2D texture)
            : base(id, name, flags)
        {
            this.Texture = texture;
        }

        /// <summary>
        /// Gets the Texture2D item icon.
        /// </summary>
        public Texture2D Texture { get; private set; }
    }
}
