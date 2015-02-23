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
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Contains the Texture property, ensuring that this object
    /// holds a Texture2D to be drawn on the screen.
    /// </summary>
    internal interface IDrawableObject : IGameObject
    {
        /// <summary>
        /// Gets the Texture2D of the Game Object.
        /// </summary>
        Texture2D Texture { get; }
    }
}
