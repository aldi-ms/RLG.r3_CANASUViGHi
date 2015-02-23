using System;

namespace RLG.R3_CANASUViGHi.Enums
{
    /// <summary>
    /// Existing flags for game objects / elements.
    /// </summary>
    [Flags]
    internal enum Flags : uint
    {
        /// <summary>
        /// Indicates do not have any flags active.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates whether the actor is under player control.
        /// </summary>
        IsPlayerControl = 1 << 0,

        /// <summary>
        /// Indicates whether the game object is transparent.
        /// <remarks>Used by Field of View.</remarks>
        /// </summary>
        IsTransparent = 1 << 1,

        /// <summary>
        /// Indicates whether the game object (eg. Tile) is visible.
        /// <remarks>Result of Field of View.</remarks>
        /// </summary>
        IsVisible = 1 << 2,

        /// <summary>
        /// Indicates whether the game object is blocked,
        /// meaning an actor cannot move through it.
        /// </summary>
        IsBlocked = 1 << 3,

        /// <summary>
        /// Indicates whether the Tile has been already seen
        /// by the Field of View.
        /// </summary>
        HasBeenSeen = 1 << 4
    }
}
