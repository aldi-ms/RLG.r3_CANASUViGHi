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
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Interfaces;
    using System;

    /// <summary>
    /// The basic game object class most other game objects should inherit from.
    /// </summary>
    internal abstract class GameObject : IGameObject
    {
        private int id;
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject" /> class.
        /// </summary>
        /// <param name="id">Object ID.</param>
        /// <param name="name">Object Name.</param>
        /// <param name="flags">Object Flags.</param>
        public GameObject(int id, string name, Flags flags)
        {
            this.ID = id;
            this.Name = name;
            this.Flags = flags;
        }

        #region Properties
        /// <summary>
        /// Gets the ID of the Terrain.
        /// </summary>
        public int ID
        {
            get 
            { 
                return this.id;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "GameObject.ID", 
                        "GameObject ID cannot be negative number!");
                }

                this.id = value;
            }
        }

        /// <summary>
        /// Gets the name of the Game Object.
        /// </summary>
        public string Name
        {
            get 
            {
                return this.name; 
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "Actor.Name",
                        "Actor Name cannot be null or empty string!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the Flags of the Game Object.
        /// </summary>
        public Flags Flags { get; set; }
        #endregion
    }
}
