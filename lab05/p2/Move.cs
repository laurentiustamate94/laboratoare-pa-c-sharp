using System;

namespace p2
{
    class Move
    {
        public int Player { get; set; }
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Move(int player, int x, int y)
        {
            Player = player;
            CoordX = x;
            CoordY = y;
        }

        public Move(int player)
            : this(player, -1, -1)
        {
            // NaN
        }
    }
}
