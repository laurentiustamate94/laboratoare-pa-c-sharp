using System;
using System.Collections.Generic;

namespace p2
{
    enum Color
    {
        WHITE,
        GRAY,
        BLACK
    }

    class Cell
    {
        public string Position { get; private set; }
        public Color Color { get; set; }
        public List<Cell> DependentCells { get; set; }
        public int InitTime { get; set; }
        public int FinishTime { get; set; }

        public Cell(string position)
        {
            Position = position;
            DependentCells = new List<Cell>();

            Color = Color.WHITE;
            InitTime = FinishTime = 0;
        }

        public override string ToString()
        {
            return Position;
        }
    }
}
