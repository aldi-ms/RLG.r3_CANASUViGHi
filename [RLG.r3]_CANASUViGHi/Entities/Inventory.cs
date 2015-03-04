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
    using RLG.R3_CANASUViGHi.Contracts;
    using RLG.R3_CANASUViGHi.GameData;
    using System;
    using System.Collections.Generic;

    internal sealed class Inventory : IInventory
    {
        private IItemContainer[] containers;
        private int containerSlots;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory" /> class.
        /// </summary>
        /// <param name="baseContainerCapacity">The Item slots of the default (base)
        /// Inventory container.</param>
        /// <param name="containerSlots">Number of slots for ItemContainers.</param>
        public Inventory(int baseContainerCapacity, int containerSlots)
        {
            this.ContainerSlots = containerSlots;
            this.containers = new IItemContainer[ContainerSlots];

            this.containers[0] = new ItemContainer(
                0, 
                ItemContainer.BaseContainer.Name,
                Enums.Flags.None,
                baseContainerCapacity,
                Sprite.UI.BagIcon);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory" /> class.
        /// The default container is set to static ItemContainer.BaseContainer.
        /// </summary>
        /// <param name="containerSlots">Number of slots for ItemContainers.</param>
        public Inventory(int containerSlots)
        {
            this.ContainerSlots = containerSlots;
            this.containers = new IItemContainer[containerSlots];
            this.containers[0] = ItemContainer.BaseContainer;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets an ItemContainer object from the Inventory.
        /// </summary>
        /// <param name="index">ItemContainer index in the Inventory.</param>
        /// <returns>ItemContainer object.</returns>
        public IItemContainer this[int index]
        {
            get 
            {
                if (index < 0 || index >= containerSlots)
                {
                    throw new ArgumentException(
                        "ItemContainer index out of range.",
                        "Inventory[int index]");
                }

                return this.containers[index]; 
            }
        }

        /// <summary>
        /// Gets the number of container slots in the Inventory.
        /// </summary>
        public int ContainerSlots
        {
            get 
            { 
                return containerSlots; 
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "ContainerSlot count should be number > 0.",
                        "Inventory.ContainerSlots");
                }

                this.containerSlots = value;
            }
        }

        /// <summary>
        /// Gets the total number of Item slots in the Inventory.
        /// </summary>
        public int ItemSlots
        {
            get
            {
                int totalItemSlots = 0;

                foreach (IItemContainer container in this.containers)
                {
                    totalItemSlots += container.Capacity;
                }

                return totalItemSlots;
            }
        }
        #endregion

        /// <summary>
        /// Pickup and store an Item in the first container with a free slot.
        /// </summary>
        /// <param name="item">The Item to pick up.</param>
        /// <returns>True if the Item was picked up successfully (eg there was free slot
        /// somewhere in the Inventory containers. False otherwise.</returns>
        public bool Pickup(IItem item)
        {
            foreach (IItemContainer container in this.containers)
            {
                if (container != null && container.Add(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Look throught the Inventory containers and remove an Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>The Item object which was dropped, or null if such was not found.</returns>
        public IItem Drop(IItem item)
        {
            foreach (IItemContainer container in this.containers)
            {
                if (container != null && container.Remove(item) == item)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
