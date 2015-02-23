using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RLG.R3_CANASUViGHi.Enums;
using RLG.R3_CANASUViGHi.GameData;
using RLG.R3_CANASUViGHi.Interfaces;
using RLG.R3_CANASUViGHi.Models;
using System;
using System.Collections.Generic;

namespace RLG.R3_CANASUViGHi.Framework
{
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
            Terrain nonBlockedTerrain = new Terrain(0, "pebble", Sprite.Floor.PebbleBrown0, Flags.None);
            Terrain blockedTerrain = new Terrain(1, "wall", Sprite.Wall.BrickBrown0, Flags.IsBlocked);

            FlatArray<ITile> resultTiles = new FlatArray<ITile>(size.X, size.Y);

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    if (RNG.Next(0, 10) > 3)
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
    }
}
