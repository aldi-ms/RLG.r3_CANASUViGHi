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
            Terrain nonBlockedTerrain = new Terrain(0, "pebble", Sprite.Floor.PebbleBrown0, Flags.IsTransparent, 20);
            Terrain blockedTerrain = new Terrain(1, "wall", Sprite.Wall.BrickBrown0, Flags.IsBlocked, -1);

            FlatArray<ITile> resultTiles = new FlatArray<ITile>(size.X, size.Y);
            IFringe tree = new Fringe(0, "red tree", Sprite.Fringe.Tree2Red, Flags.IsBlocked);

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    if (RNG.Next(0, 10) > 1)
                    {
                        if (RNG.Next(0, 25) > 1)
                        {
                            resultTiles[x, y] = new Tile(nonBlockedTerrain, null, 0, null);
                        }
                        else
                        {
                            resultTiles[x, y] = new Tile(nonBlockedTerrain, 0, null, tree);
                        }
                    }
                    else
                    {
                        resultTiles[x, y] = new Tile(blockedTerrain, null, 0, null);
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
            return new Actor(1, "bot", 50, 10, Sprite.Monster.Rat, Flags.None);
        }

        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;

                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;

                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;

                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;

                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;

                }
            }
            
            byte red = Convert.ToByte(r * 255.0f);
            byte green = Convert.ToByte(g * 255.0f);
            byte blue = Convert.ToByte(b * 255.0f);

            return new Color(red, green, blue);

        }
    }
}
