using System;
using System.Collections.Generic;

namespace p1
{
    class State
    {
        #region Properties

        public int Distance { get; set; }
        public State Parent { get; set; }

        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public static int RowsCount { get; set; }
        public static int ColumnsCount { get; set; }
        public static bool[,] matrix { get; set; }

        #endregion

        public State(int x, int y)
        {
            CoordX = x;
            CoordY = y;
        }
        public State(int x, int y, State parent, int distance)
            : this(x, y)
        {

            Parent = parent;
            Distance = distance;
        }

        public int ApproximateDistance(State other)
        {
            var distance = 0;

            /* 
             * TODO
             * 
             * Functie admisibila care sa estimeze 
             * costul pana la starea finala 
             */

            return distance;
        }

        public static void Initialize(int rowsCount, int columnsCount)
        {
            State.RowsCount = rowsCount;
            State.ColumnsCount = columnsCount;

            State.matrix = new bool[rowsCount, columnsCount];
        }

        public List<State> ExpandCurrentState()
        {
            var neighbours = new List<State>();

            /* above */
            if (CoordY > 0 && matrix[CoordY - 1, CoordX])
                neighbours.Add(new State(CoordX, CoordY - 1, this, Distance + 1));

            /* below */
            if (CoordY < RowsCount - 1 && matrix[CoordY + 1, CoordX])
                neighbours.Add(new State(CoordX, CoordY + 1, this, Distance + 1));

            /* left */
            if (CoordX > 0 && matrix[CoordY, CoordX - 1])
                neighbours.Add(new State(CoordX - 1, CoordY, this, Distance + 1));

            /* right */
            if (CoordX < ColumnsCount - 1 && matrix[CoordY, CoordX + 1])
                neighbours.Add(new State(CoordX + 1, CoordY, this, Distance + 1));

            return neighbours;
        }

        private void PrintReversePath(State current)
        {
            if (current == null)
                return;

            PrintReversePath(current.Parent);

            Console.WriteLine(current);
        }

        public void PrintPath()
        {
            PrintReversePath(this);
        }

        public override int GetHashCode()
        {
            var firstHash = CoordX.GetHashCode() + CoordY.GetHashCode();
            var secondHash = Parent.GetHashCode() + Distance.GetHashCode();

            return (firstHash + secondHash) * secondHash + firstHash;
        }

        public override bool Equals(object obj)
        {
            var currentState = obj as State;

            return CoordX == currentState.CoordX && CoordY == currentState.CoordY;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", CoordY, CoordX);
        }
    }
}
