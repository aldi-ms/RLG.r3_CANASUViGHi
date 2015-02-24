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

    // Basic Map cell / keeps IDs to all objects contained in a Tile.
    internal sealed class Tile : ITile
    {
        private Flags flags;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile" /> class.
        /// </summary>
        /// <param name="terrain">Terrain ID.</param>
        /// <param name="fringe">Game Object ID.</param>
        /// <param name="itemList">to be implemented...</param>
        /// <param name="unit">Unit ID.</param>
        public Tile(ITerrain terrain, int fringe, int itemList, IActor unit) 
        {
            this.Terrain = terrain;
            this.Fringe = fringe;
            this.Actor = unit;

            // Set flags to cumulative from other flags (see Flags)
            this.Flags = Flags.None;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the Terrain ID of the Tile.
        /// </summary>
        public ITerrain Terrain { get; set; }

        /// <summary>
        /// Gets or sets the Fringe ID of the Tile.
        /// </summary>
        public int Fringe { get; set; }

        /// <summary>
        /// Gets or sets the Item List ID of the Tile.
        /// </summary>
        public int ItemList { get; set; }

        /// <summary>
        /// Gets or sets the Actor ID of the Tile.
        /// </summary>
        public IActor Actor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Tile is visible.
        /// </summary>
        public bool IsVisible
        {
            get { return this.Flags.HasFlag(Flags.IsVisible); }

            set 
            {
                if (value)
                {
                    this.Flags |= Flags.IsVisible;
                }
                else
                {
                    this.Flags &= ~Flags.IsVisible;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Tile is transparent.
        /// </summary>
        public bool IsTransparent 
        {
            get
            {
                return this.Flags.HasFlag(Flags.IsTransparent);
            }
        }

        /// <summary>
        /// Clears the Tile specific Flags, and only them.
        /// </summary>
        public void ClearFlags()
        {
            if (this.Flags.HasFlag(Flags.HasBeenSeen))
            {
                this.Flags = Flags.None;
                this.Flags = Flags.HasBeenSeen;
            }
            else
            {
                this.Flags = Flags.None;
            }
        }

        /// <summary>
        /// Gets the Tile Flags.
        /// </summary>
        public Flags Flags
        {
            get
            {
                // cumulative from terrain, gameobj, itemlist & actor Flags
                if (this.Actor != null)
                {
                    return this.flags | this.Terrain.Flags | this.Actor.Flags;
                }
                else
                {
                    return this.flags | this.Terrain.Flags;
                }
            }

            set 
            {
                this.flags = value;
            }
        }
        #endregion
    }
}
