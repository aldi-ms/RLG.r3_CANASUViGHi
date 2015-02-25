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

    /// <summary>
    /// A sound object.
    /// </summary>
    internal class Sound : ISound
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sound" /> class.
        /// </summary>
        /// <param name="sourceObject">The source of the sound.</param>
        /// <param name="soundType">Type of sound.</param>
        /// <param name="sound">Sound string representation.</param>
        public Sound(
            ISoundSourceObject sourceObject,
            SoundType soundType,
            string sound)
        {
            this.Source = sourceObject;
            this.Type = soundType;
            this.StringValue = sound;
        }

        /// <summary>
        /// Gets the sound source.
        /// </summary>
        public ISoundSourceObject Source { get; private set; }

        /// <summary>
        /// Gets the sound type.
        /// </summary>
        public SoundType Type { get; private set; }

        /// <summary>
        /// Gets the sound string representation.
        /// </summary>
        public string StringValue { get; private set; }
    }
}
