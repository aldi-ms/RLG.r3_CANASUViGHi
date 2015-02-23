using RLG.R3_CANASUViGHi.Interfaces;
using RLG.R3_CANASUViGHi.Framework;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RLG.R3_CANASUViGHi.Interfaces
{
    interface IMap<T> where T : ITile
    {
        FlatArray<T> Tiles { get; set; }
        T this[Point index] { get; set; }

        void Draw(SpriteBatch spriteBatch, Point centre);
        bool CheckTile(Point p);
    }
}
