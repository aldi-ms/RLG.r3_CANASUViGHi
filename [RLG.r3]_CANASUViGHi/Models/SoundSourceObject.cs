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
    /// Abstract class implementing <see cref="GameObject"/> and <see cref="ISoundSourceObject<IGameObject"/>,
    /// base for game objects that can make sounds.
    /// </summary>
    internal abstract class SoundSourceObject : GameObject, ISoundSourceObject<IGameObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoundSourceObject" /> class.
        /// </summary>
        /// <param name="soundReceiver">The object used to receive the sounds.</param>
        /// <param name="id">ID of this GameObject.</param>
        /// <param name="name">Name of this GameObject.</param>
        /// <param name="flags">GameObject Flags.</param>
        public SoundSourceObject(int id, string name, Flags flags)
            : base(id, name, flags)
        { }

        /// <summary>
        /// Gets the Sound Receiver object for the Actor.
        /// </summary>
        public ISoundReceiver SoundReceiver { get; set; }

        /// <summary>
        /// Make a sound, and send it to the SoundReceiver.
        /// </summary>
        /// <param name="soundType">Type of sound.</param>
        /// <param name="sound">The sound string representation.</param>
        public void MakeSound(SoundType soundType, string sound)
        {
            if (SoundReceiver == null)
            {
                throw new ArgumentNullException("SoundSource.SoundReceiver cannot be null when calling method MakeSound.");
            }

            ISound madeSound = new Sound(
                this,
                soundType,
                sound);

            this.SoundReceiver.ReceiveSound(madeSound);
        }
    }
}
