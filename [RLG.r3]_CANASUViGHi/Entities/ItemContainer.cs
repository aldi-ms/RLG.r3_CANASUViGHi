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
    using RLG.R3_CANASUViGHi.GameData;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An Item Container class.
    /// </summary>
    internal class ItemContainer : GameObject, IItemContainer
    {
        /// <summary>
        /// The base container - id 0, name Base Inventory.
        /// </summary>
        internal static ItemContainer BaseContainer = 
            new ItemContainer(0, "Base Inventory", Flags.None, 20, Sprite.UI.BagIcon);

        private readonly int capacity;
        private List<IItem> contents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemContainer" /> class.
        /// </summary>
        /// <param name="id">The ID of the Actor.</param>
        /// <param name="name">Name of the Actor.</param>
        /// <param name="flags">Item Container Flags.</param>
        /// <param name="capacity">Capacity of the Container.</param>
        /// <param name="texture">Texture representing the Container icon.</param>
        public ItemContainer(int id, string name, Flags flags, int capacity, Texture2D texture)
            : base(id, name, flags)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(
                    "Item Container capacity cannot be <= 0.",
                    "ItemContainer.Capacity");
            }

            this.capacity = capacity;
            this.Texture = texture;
        }

        #region Properties
        /// <summary>
        /// Gets the capacity of the ItemContainer.
        /// </summary>
        public int Capacity
        {
            get { return this.capacity; }
        }

        /// <summary>
        /// Gets the count of items in the container.
        /// </summary>
        public int Count
        {
            get { return this.ContentCopy.Count; } 
        }
        #endregion

        /// <summary>
        /// Add an Item object to the container.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>True if the item was added successfully (there was free space in the container).
        /// False otherwise.</returns>
        public bool Add(IItem item)
        {
            if (this.Count < this.Capacity)
            {
                this.ContentCopy.Add(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove an Item from the container.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>If the item exists returns itself. Otherwise null.</returns>
        public IItem Remove(IItem item)
        {
            if (this.ContentCopy.Remove(item))
            {
                return item;
            }

            return null;
        }

        /// <summary>
        /// Gets a copy list of the container Item list.
        /// </summary>
        public List<IItem> ContentCopy
        {
            get
            {
                IItem[] itemArray = new IItem[this.Count];
                contents.CopyTo(itemArray);
                return new List<IItem>(itemArray); 
            }

            private set 
            {
                this.contents = value; 
            }
        }

        /// <summary>
        /// Gets the Texture2D icon representing the ItemContainer.
        /// </summary>
        public Texture2D Texture { get; private set; }
    }
}
