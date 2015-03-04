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

namespace RLG.R3_CANASUViGHi.Entities
{
    using RLG.R3_CANASUViGHi.Enums;
    using RLG.R3_CANASUViGHi.Contracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Basic Map Tile implementation, keeps refences to the objects
    ///  contained in a Tile.
    /// </summary>
    internal sealed class Tile : ITile
    {
        private Flags flags;
        private ITerrain terrain;
        private List<IFringe> fringeList;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Tile" /> class.
        /// </summary>
        /// <param name="terrain">Terrain object.</param>
        /// <param name="fringe">List of Fringe objects.</param>
        /// <param name="itemList">to be implemented...</param>
        /// <param name="actor">Actor object.</param>
        public Tile(ITerrain terrain, List<IFringe> fringe, int itemList, IActor actor) 
        {
            this.Terrain = terrain;
            this.FringeList = fringe;
            this.Actor = actor;

            // Set flags to cumulative from other flags (see Flags)
            this.Flags = Flags.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile" /> class.
        /// </summary>
        /// <param name="terrain">Terrain object.</param>
        /// <param name="itemList">to be implemented...</param>
        /// <param name="actor">Actor object.</param>
        /// <param name="fringe">Parameterized Fringe objects.</param>
        public Tile(ITerrain terrain, int itemList, IActor actor, params IFringe[] fringe)
            :this(terrain,  new List<IFringe>(fringe), itemList, actor)
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Terrain object in the Tile.
        /// </summary>
        public ITerrain Terrain
        {
            get 
            { 
                return this.terrain; 
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Tile.Terrain",
                        "Tile Terrain cannot be null!");
                }

                this.terrain = value;
            }
        }

        /// <summary>
        /// Gets or sets the Fringe object in the Tile.
        /// </summary>
        public List<IFringe> FringeList 
        {
            get
            { 
                return this.fringeList;
            }

            set
            {
                if (value == null)
                {
                    this.fringeList = new List<IFringe>();
                }
                else
                {
                    this.fringeList = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Item List in the Tile.
        /// </summary>
        public int ItemList { get; set; }

        /// <summary>
        /// Gets or sets the Actor object in the Tile.
        /// </summary>
        public IActor Actor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Tile is visible.
        /// </summary>
        /// <remarks>Uses Flags.IsVisible.</remarks>
        public bool IsVisible
        {
            get 
            {
                return this.Flags.HasFlag(Flags.IsVisible); 
            }

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
        /// Gets a value indicating whether the Tile is transparent.
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
                Flags cumulativeFlags = this.flags | this.Terrain.Flags;

                if (this.Actor != null)
                {
                    cumulativeFlags |= this.Actor.Flags;
                }

                if (this.FringeList.Count > 0)
                {
                    foreach (IFringe fringe in this.FringeList)
                    {
                        cumulativeFlags |= fringe.Flags;
                    }
                }

                return cumulativeFlags;
            }

            set 
            {
                this.flags = value;
            }
        }
        #endregion
    }
}
