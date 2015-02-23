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

namespace RLG.R3_CANASUViGHi.Framework
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.GameData;
    using RLG.R3_CANASUViGHi.Interfaces;
    using RLG.R3_CANASUViGHi.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains static tools used by the game.
    /// <remarks>Eg. Map generators.</remarks>
    /// </summary>
    internal static class Tools
    {
        /// <summary>
        /// Static Random Number Generator.
        /// </summary>
        internal static Random RNG = new Random();

        /// <summary>
        /// Most basic random map generator.
        /// </summary>
        /// <typeparam name="T">Type of flat array elements, 
        /// implementing the ITile interface.</typeparam>
        /// <param name="blocked">A List of textures to use for generating
        /// a free-to-pass (not blocked) terrain.</param>
        /// <param name="nonBlocked">A List of textures to use for generating
        /// blocked terrain.</param>
        /// <returns>A <see cref="FlatArray"/> of <typeparamref name="T"/>
        /// elements.</returns>
        public static FlatArray<ITile> GenerateMap(Point size)
        {
            Terrain nonBlockedTerrain = new Terrain(0, "pebble", Sprite.Floor.PebbleBrown0, Flags.None, 20);
            Terrain blockedTerrain = new Terrain(1, "wall", Sprite.Wall.BrickBrown0, Flags.IsBlocked, -1);

            FlatArray<ITile> resultTiles = new FlatArray<ITile>(size.X, size.Y);

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    if (RNG.Next(0, 10) > 2)
                    {
                        resultTiles[x, y] = new Tile(nonBlockedTerrain, 0, 0, null);
                    }
                    else
                    {
                        resultTiles[x, y] = new Tile(blockedTerrain, 0, 0, null);
                    }
                }
            }

            return resultTiles;
        }

        /// <summary>
        /// For non-player controlled Actors, testing only!
        /// </summary>
        /// <returns>Random Cardinal Direction.</returns>
        public static CardinalDirection DrunkardWalk()
        {
            return (CardinalDirection)RNG.Next(0, 8);
        }

        //// Randomize monster generation.
        /// <summary>
        /// Generate a (test-case) monster.
        /// </summary>
        /// <returns>An object implementing IActor.</returns>
        public static IActor GenerateMonster()
        {
            return new Actor(1, "bot", 0, 8, Sprite.Monster.Rat, Flags.None);
        }
    }
}
