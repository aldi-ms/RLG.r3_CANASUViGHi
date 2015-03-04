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
    using System.Collections.Generic;

    /// <summary>
    /// Base interface for Actor Inventory.
    /// </summary>
    internal interface IInventory
    {
        /// <summary>
        /// Gets an ItemContainer object from the Inventory.
        /// </summary>
        /// <param name="index">ItemContainer index in the Inventory.</param>
        /// <returns>ItemContainer object.</returns>
        IItemContainer this[int index] { get; }

        /// <summary>
        /// Gets the number of container slots in the Inventory.
        /// </summary>
        int ContainerSlots { get; }

        /// <summary>
        /// Gets the total number of Item slots in the Inventory.
        /// </summary>
        int ItemSlots { get; }

        /// <summary>
        /// Pickup and store an Item in the first container with a free slot.
        /// </summary>
        /// <param name="item">The Item to pick up.</param>
        /// <returns>True if the Item was picked up successfully (eg there was free slot
        /// somewhere in the Inventory containers. False otherwise.</returns>
        bool Pickup(IItem item);

        /// <summary>
        /// Look throught the Inventory containers and remove an Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>The Item object which was dropped, or null if such was not found.</returns>
        IItem Drop(IItem item);
    }
}
