using Microsoft.Xna.Framework;
using RLG.R3_CANASUViGHi.Enums;

namespace RLG.R3_CANASUViGHi.Framework
{
    internal static class CardinalDirectionExtensions
    {
        public static Point GetDeltaCoordinate(this CardinalDirection direction)
        {
            int dX = 0;
            int dY = 0;

            switch (direction)
            {
                case CardinalDirection.North:
                    dY = -1;
                    break;

                case CardinalDirection.South:
                    dY = 1;
                    break;

                case CardinalDirection.West:
                    dX = -1;
                    break;

                case CardinalDirection.East:
                    dX = 1;
                    break;

                case CardinalDirection.NorthWest:
                    dX = -1;
                    dY = -1;
                    break;

                case CardinalDirection.NorthEast:
                    dX = 1;
                    dY = -1;
                    break;

                case CardinalDirection.SouthEast:
                    dX = 1;
                    dY = 1;
                    break;

                case CardinalDirection.SouthWest:
                    dX = -1;
                    dY = 1;
                    break;
            }

            return new Point(dX, dY);
        }
    }
}
