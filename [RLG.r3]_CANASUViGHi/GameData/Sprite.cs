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

namespace RLG.R3_CANASUViGHi.GameData
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.GameData.Sprites;

    /// <summary>
    /// Static class, keeping all loaded sprites / textures.
    /// </summary>
    internal static class Sprite
    {
        /// <summary>
        /// Keeps the size of the sprites (TileSize x TileSize) in pixels.
        /// <para>Ex. 32x32.</para>
        /// </summary>
        internal const int TileSize = 32;

        /// <summary>
        /// Gets loaded Actor sprites.
        /// </summary>
        internal static PlayerSprites Player { get; private set; }

        /// <summary>
        /// Gets loaded Floor sprites.
        /// </summary>
        internal static FloorSprites Floor { get; private set; }

        /// <summary>
        /// Gets loaded wall sprites.
        /// </summary>
        internal static WallSprites Wall { get; private set; }

        internal static MonsterSprites Monster { get; private set; }

        /// <summary>
        /// Static initializer for loading all sprites / textures.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        internal static void LoadSprites(ContentManager content)
        {
            if (Player == null)
            {
                Player = new PlayerSprites(content);
            }

            if (Floor == null)
            {
                Floor = new FloorSprites(content);
            }

            if (Wall == null)
            {
                Wall = new WallSprites(content);
            }

            if (Monster == null)
            {
                Monster = new MonsterSprites(content);
            }
        }
    }
}
