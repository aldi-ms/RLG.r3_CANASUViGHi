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

namespace RLG.R3_CANASUViGHi.GameData.Sprites
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Load and keep all fringe textures in properties.
    /// </summary>
    internal sealed class FringeSprites
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FringeSprites" /> class.
        /// Loads all fringe sprites.
        /// </summary>
        /// <param name="content">MonoGame ContentManager.</param>
        public FringeSprites(ContentManager contentManager)
        {
            this.Tree2Yellow = contentManager.Load<Texture2D>("tiles/dungeon/wall/tree2_yellow");
            this.Tree2Red = contentManager.Load<Texture2D>("tiles/dungeon/wall/tree2_red");
        }

        /// <summary>
        /// Gets sprite "tree2_yellow".
        /// </summary>
        internal Texture2D Tree2Yellow { get; private set; }

        /// <summary>
        /// Gets sprite "tree2_red".
        /// </summary>
        internal Texture2D Tree2Red { get; private set; }
    }
}
