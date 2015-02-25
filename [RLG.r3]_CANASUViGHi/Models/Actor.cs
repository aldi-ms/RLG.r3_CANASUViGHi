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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Framework;
    using RLG.R3_CANASUViGHi.Interfaces;
    using RLG.R3_CANASUViGHi.Models;
    using System;

    /// <summary>
    /// Information about a Game Actor.
    /// </summary>
    internal sealed class Actor : SoundSourceObject, IActor
    {
        private bool hasSpawned = false;
        private IMap<ITile> map;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Actor" /> class.
        /// </summary>
        /// <param name="id">The ID of the Actor.</param>
        /// <param name="name">Name of the Actor.</param>
        /// <param name="energy">The Actor energy.</param>
        /// <param name="speed">The Actor speed.</param>
        /// <param name="position">Position of the Actor.</param>
        /// <param name="texture">The texture representing the Actor.</param>
        /// <param name="flags">Actor Flags. <remarks>Flags.IsBlocked is
        /// automatically raised for an Actor.</remarks></param>
        public Actor(
            int id, 
            string name,
            int energy,
            int speed, 
            Texture2D texture, 
            Flags flags)
            : base(id, name, flags |= Flags.IsBlocked)
        {
            this.Energy = energy;
            this.Speed = speed;
            this.Texture = texture;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the Actor Energy.
        /// <para>Needed for the turn-based game system.</para>
        /// </summary>
        public int Energy { get; set; }

        /// <summary>
        /// Gets or sets the Actor Speed.
        /// <para>Needed for the turn-based game system.</para>
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Gets or sets the position of the Actor.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets the Texture2D representing the Actor.
        /// </summary>
        public Texture2D Texture { get; private set; }
        #endregion

        /// <summary>
        /// Spawn the actor on the indicated map and coordinates.
        /// </summary>
        /// <param name="map">The Map to spawn the Actor on.</param>
        /// <param name="spawnPoint">The position at which to spawn the Actor.</param>
        /// <returns>Whether the Spawn was executed and successful.</returns>
        public bool Spawn(IMap<ITile> map, Point spawnPoint)
        {
            if (!this.hasSpawned)
            {
                string block;
                if (map.CheckTile(spawnPoint, out block))
                {
                    this.map = map;
                    this.Position = spawnPoint;

                    this.map[this.Position].Actor = this;
                    this.hasSpawned = true;

                    this.MakeSound(SoundType.Yell, "I'm here to kick some ass!!!");

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Move the Actor in the specified direction.
        /// </summary>
        /// <param name="direction">The cardinal directions of the move.</param>
        /// <returns>Returns the cost of the move or 0 if unsuccessful.</returns>
        public int Move(CardinalDirection direction)
        {
            if (this.map == null)
            {
                throw new ArgumentException(
                    "Actor map cannot be null when calling this method! Have you spawned the Actor?",
                    "Actor.map");
            }

            string block;
            Point newPosition = this.Position + direction.GetDeltaCoordinate();

            if (this.map.CheckTile(newPosition, out block))
            {
                this.map[this.Position].Actor = null;
                this.map[this.Position].ClearFlags();
                this.map[newPosition].Actor = this;
                this.Position = newPosition;

                return this.map[this.Position].Terrain.MovementCost;
            }
            else if (!string.IsNullOrEmpty(block))
            {
                this.MakeSound(SoundType.Bump, block);
            }

            return 0;
        }
    }
}
