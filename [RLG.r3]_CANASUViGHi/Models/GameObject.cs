using RLG.R3_CANASUViGHi.Enums;
using RLG.R3_CANASUViGHi.Interfaces;
using System;

namespace RLG.R3_CANASUViGHi.Models
{
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
