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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Framework;
    using RLG.R3_CANASUViGHi.GameData;
    using RLG.R3_CANASUViGHi.Interfaces;
    using System;

    /// <summary>
    /// Class keeping all information for a given Map object.
    /// </summary>
    /// <typeparam name="T">Map tile elements, implementing ITile interface.</typeparam>
    internal sealed class Map<T> : GameObject, IMap<T>
        where T : ITile
    {
        private Point viewBoxTileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Map" /> class.
        /// </summary>
        /// <param name="tiles">FlatArray of <typeparamref name="T"/> elements,
        /// representing the actual Game Map.</param>
        /// <param name="id">Map ID.</param> 
        /// <param name="name">Map Name.</param>
        /// <param name="flags">Map flags.</param>
        /// <param name="viewBoxTileSize">Size of the Map view-box in number of Tiles.</param>
        public Map(FlatArray<T> tiles, int id, string name, Flags flags, Point viewBoxTileSize)
            : base(id, name, flags)
        {
            this.Tiles = tiles;
            this.ViewBoxTileSize = viewBoxTileSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map" /> class.
        /// </summary>
        /// <param name="tiles">FlatArray of <typeparamref name="T"/> elements,
        /// representing the actual Game Map.</param>
        /// <param name="id">Map ID.</param>
        /// <param name="name">Map Name.</param>
        public Map(FlatArray<T> tiles, int id, string name)
            : this(tiles, id, name, Flags.None, new Point(16, 10))
        { }

        #region Properties
        /// <summary>
        /// Get or sets the Tile at the selected position.
        /// </summary>
        /// <param name="x">"X" dimension / width of the Tile.</param>
        /// <param name="y">"Y" dimension / width of the Tile.</param>
        /// <returns>The <typeparamref name="T"/> Tile at the selected position.</returns>
        public T this[int x, int y]
        {
            get { return this.Tiles[x, y]; }
            set { this.Tiles[x, y] = value; }
        }

        /// <summary>
        /// Get or sets the Tile at the selected Point.
        /// </summary>
        /// <param name="index">A Point keeping the coordinates of a Tile.</param>
        /// <returns>The  <typeparamref name="T"/> Tile at the selected Point.</returns>
        public T this[Point index]
        {
            get { return this[index.X, index.Y]; }
            set { this[index.X, index.Y] = value; }
        }

        /// <summary>
        /// Gets or sets the <typeparamref name="T"/> elements of the Game Map.
        /// </summary>
        public FlatArray<T> Tiles { get; set; }

        /// <summary>
        /// Gets or sets the Map view-box size in number of Tiles to draw.
        /// </summary>
        public Point ViewBoxTileSize
        {
            get { return this.viewBoxTileSize; }

            set
            {
                if (value.X * Sprite.TileSize > Engine.GameEngine.ScreenWidth ||
                    value.Y * Sprite.TileSize > Engine.GameEngine.ScreenHeight)
                {
                    throw new ArgumentException(
                        "Map view-box is out of Screen bounds!",
                        "viewBoxTileSize");
                }

                this.viewBoxTileSize = value;
            }
        }
        #endregion

        /// <summary>
        /// Draw the map on the selected coordinates.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch used to draw the Map.</param>
        /// <param name="center">Center the screen around this point.</param>
        public void Draw(SpriteBatch spriteBatch, Point center)
        {
            spriteBatch.Begin();

            // Get the start (Tile)coordinates  for the Map
            Point startTile = new Point(
                center.X - (this.ViewBoxTileSize.X / 2),
                center.Y - (this.ViewBoxTileSize.Y / 2));

            // Check coordinates lower bound < 0
            if (startTile.X < 0)
            {
                startTile.X = 0;
            }
            if (startTile.Y < 0)
            {
                startTile.Y = 0;
            }

            // Check coordinates higher bound > 0
            if (startTile.X + this.ViewBoxTileSize.X >= this.Tiles.Height)
            {
                startTile.X = this.Tiles.Height - this.ViewBoxTileSize.X;
            }
            if (startTile.Y + this.ViewBoxTileSize.Y >= this.Tiles.Width)
            {
                startTile.Y = this.Tiles.Width - this.ViewBoxTileSize.Y;
            }

            for (int x = 0; x < this.ViewBoxTileSize.X; x++)
            {
                for (int y = 0; y < this.ViewBoxTileSize.Y; y++)
                {
                    Vector2 drawPosition = new Vector2(10 + (Sprite.TileSize * x), 10 + (Sprite.TileSize * y));
                    Point tile = new Point(startTile.X + x, startTile.Y + y);

                    //if (this[tile].IsVisible)
                    if (true)
                    {
                        // Draw the Terrain first as it exists for every Tile.
                        spriteBatch.Draw(this[tile].Terrain.Texture, drawPosition);

                        /* *
                        if (this[tile].GameObject != null)
                        {
                            spriteBatch.Draw(this[tile].GameObject.Texture, drawPosition);
                        }
                        if (this[tile].Item != null)
                        {
                            spriteBatch.Draw(this[tile].Item.Texture, drawPosition);
                        }
                         * 
                        * */
                        if (this[tile].Actor != null)
                        {
                            spriteBatch.Draw(this[tile].Actor.Texture, drawPosition);
                        }
                    }
                    else if (this[tile].Flags.HasFlag(Flags.HasBeenSeen))
                    {
                        spriteBatch.Draw(this[tile].Terrain.Texture, drawPosition, Color.DarkGray);
                    }
                }
            }

            spriteBatch.End();
        }

        /// <summary>
        /// Indicates whether the Tile at this position
        /// is a valid (in map bound && not blocked) Tile.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>True if the tile is a valid destination Tile, otherwise false.</returns>
        public bool CheckTile(Point p)
        {
            // Return false if the coordinates are out if map-bounds.
            if (p.X < 0 || p.X >= this.Tiles.Width ||
                p.Y < 0 || p.Y >= this.Tiles.Height)
            {
                return false;
            }

            // Return false if the tile is blocked.
            if (this[p].Flags.HasFlag(Flags.IsBlocked))
            {
                return false;
            }

            // Redundant check? In that case Tile should have IsBlocked flag!
            if (this[p].Actor != null)
            {
                return false;
            }

            return true;
        }
    }
}
