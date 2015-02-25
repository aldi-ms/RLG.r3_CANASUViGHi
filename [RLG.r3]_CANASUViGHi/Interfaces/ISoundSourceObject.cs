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

namespace RLG.R3_CANASUViGHi.Interfaces
{
    using RLG.R3_CANASUViGHi.Enums;

    /// <summary>
    /// Interface for sound source objects.
    /// </summary>
    /// <typeparam name="T">Type of object, which should implement
    /// <see cref="IGameObject"/></typeparam>
    internal interface ISoundSourceObject : IGameObject
    {
        /// <summary>
        /// Gets the Sound Receiver object for the Actor.
        /// </summary>
        ISoundReceiver SoundReceiver { get; set; }

        /// <summary>
        /// Make a sound, and send it to the SoundReceiver.
        /// </summary>
        /// <param name="soundType">Type of sound.</param>
        /// <param name="sound">The sound's string representation.</param>
        void MakeSound(SoundType soundType, string sound);
    }
}
