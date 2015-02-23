using Microsoft.Xna.Framework;
using RLG.R3_CANASUViGHi.Enums;

namespace RLG.R3_CANASUViGHi.Interfaces
{
    /// <summary>
    /// Interface for all game units 
    /// (mobs, characters, etc.) that can act.
    /// </summary>
    internal interface IActor : IDrawableObject
    {
        /// <summary>
        /// Gets or sets the energy of the Actor.
        /// </summary>
        int Energy { get; set; }

        /// <summary>
        /// Gets or sets the speed of the Actor.
        /// </summary>
        int Speed { get; set; }

        /// <summary>
        /// Gets or sets the location of the Actor.
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// Move the Actor in the specified direction.
        /// </summary>
        /// <param name="direction">One of the 8 directions.</param>
        /// <returns>Indicates whether the move was successful.</returns>
        bool Move(CardinalDirection direction);


        /// <summary>
        /// Spawn the actor on the indicated map and coordinates.
        /// </summary>
        /// <param name="map">The Map to spawn the Actor on.</param>
        /// <param name="spawnPoint">The position at which to spawn the Actor.</param>
        /// <returns>Whether the Spawn was executed and successful.</returns>
        bool Spawn(IMap<ITile> map, Point spawnPoint);
    }
}
