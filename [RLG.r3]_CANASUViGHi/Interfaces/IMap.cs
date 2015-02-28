﻿/* *
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

namespace RLG.R3_CANASUViGHi.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RLG.R3_CANASUViGHi.Interfaces;
    using RLG.R3_CANASUViGHi.Framework;

    interface IMap<T>
        where T : ITile
    {
        FlatArray<T> Tiles { get; set; }

        T this[int x, int y] { get; set; }

        T this[Point index] { get; set; }

        Point ViewBoxTileCount { get; set; }

        void Draw(SpriteBatch spriteBatch, Point centre);

        bool CheckTile(Point p, out string blocking);

        ITile GetTileAtWindowCoordinates(Point position);
    }
}
