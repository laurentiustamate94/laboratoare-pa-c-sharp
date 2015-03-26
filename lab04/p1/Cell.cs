using System;
using System.Collections.Generic;

namespace p1
{
    class Cell
    {
        bool[] domain;
        private int _value;

        public int Row { get; set; }
        public int Column { get; set; }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                domain = Array.ConvertAll<bool, bool>(domain, x => x = false);

                domain[value - 1] = true;
                DomainSize = 1;
            }
        }
        public int DomainSize { get; set; }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;

            domain = new bool[9];
            domain = Array.ConvertAll<bool, bool>(domain, x => x = true);

            DomainSize = 9;
        }

        public Cell(int row, int column, int value)
        {
            Value = value;
            Row = row;
            Column = column;

            domain = new bool[9];
            domain = Array.ConvertAll<bool, bool>(domain, x => x = false);

            domain[value - 1] = true;
            DomainSize = 1;
        }

        public void RemoveFromDomain(int value)
        {
            if (domain[value - 1])
            {
                domain[value - 1] = false;
                DomainSize--;
            }
        }

        public List<int> GetPossibleValues()
        {
            var result = new List<int>();

            for (int i = 0; i < 9; i++)
                if (domain[i]) result.Add(i + 1);

            return result;
        }

        public Cell Clone()
        {
            var cell = Value == 0 ? new Cell(Row, Column) : new Cell(Row, Column, Value);

            domain.CopyTo(cell.domain, 0);

            cell.DomainSize = DomainSize;

            return cell;
        }
    }
}
