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
    /// Base interface for game-item containers (whether character bag
    /// or chest with loot).
    /// </summary>
    internal interface IItemContainer : IDrawableObject
    {
        /// <summary>
        /// Gets the capacity of the ItemContainer.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Gets the count of items in the container.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets a copy list of the container Item list.
        /// </summary>
        List<IItem> ContentCopy { get; }

        /// <summary>
        /// Add an Item object to the container.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>True if the item was added successfully (there was free space in the container).
        /// False otherwise.</returns>
        bool Add(IItem item);

        /// <summary>
        /// Remove an Item from the container.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>If the item exists returns itself. Otherwise null.</returns>
        IItem Remove(IItem item);
    }
}
