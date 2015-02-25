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

namespace RLG.R3_CANASUViGHi.GameData.Sprites
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Load and keep all wall sprites / textures.
    /// </summary>
    internal sealed class WallSprites
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WallSprites" /> class.
        /// Loads all wall sprites.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        public WallSprites(ContentManager content)
        {
            this.BrickBrown0 = content.Load<Texture2D>("tiles/dungeon/wall/brick_brown0");
        }

        /// <summary>
        /// Gets sprite "brick_brown0".
        /// </summary>
        internal Texture2D BrickBrown0 { get; private set; }
    }
}
