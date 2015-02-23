using RLG.R3_CANASUViGHi.Enums;
using RLG.R3_CANASUViGHi.Interfaces;

namespace RLG.R3_CANASUViGHi.Models
{
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
        /// Gets the Tile Flags.
        /// </summary>
        public Flags Flags
        {
            get
            {
                // cumulative from terrain, gameobj, itemlist, unit Flags?
                if (this.Actor != null)
                {
                    return this.flags | this.Terrain.Flags | this.Actor.Flags;
                }
                else
                {
                    return this.flags | this.Terrain.Flags;
                }
            }

            private set 
            {
                this.flags = value;
            }
        }
        #endregion
    }
}
