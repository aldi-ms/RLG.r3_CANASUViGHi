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
    using Microsoft.Xna.Framework;
    using RLG.R3_CANASUViGHi.Enums;

    /// <summary>
    /// Interface for all game units 
    /// (mobs, characters, etc.) that can act.
    /// </summary>
    internal interface IActor : IDrawableObject
    {
        /// <summary>
        /// Gets or sets the energy of the Actor.
        /// </summary>
        int Energy { get; set; }

        /// <summary>
        /// Gets or sets the speed of the Actor.
        /// </summary>
        int Speed { get; set; }

        /// <summary>
        /// Gets or sets the location of the Actor.
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// Move the Actor in the specified direction.
        /// </summary>
        /// <param name="direction">One of the 8 directions.</param>
        /// <returns>Returns the cost of the move or 0 if unsuccessful.</returns>
        int Move(CardinalDirection direction);
        
        /// <summary>
        /// Spawn the actor on the indicated map and coordinates.
        /// </summary>
        /// <param name="map">The Map to spawn the Actor on.</param>
        /// <param name="spawnPoint">The position at which to spawn the Actor.</param>
        /// <returns>Whether the Spawn was executed and successful.</returns>
        bool Spawn(IMap<ITile> map, Point spawnPoint);
    }
}
