using System;
using System.IO;
using System.Collections.Generic;

namespace p1
{
    class Program
    {
        static State initialState;
        static State solutionState;

        static void Main(string[] args)
        {
            ReadData("Resources/date.in");

            var open = new SortedSet<State>(new StateComparator(Algorithm.AStar, solutionState));

            /* Initial doar nodul de start este in curs de explorare */
            open.Add(initialState);

            /* Pentru nodurile care au fost deja expandate. */
            var closed = new List<State>();

            /* TODO: A* */
        }

        public static void ReadData(string filename)
        {
            int x, y;

            try
            {
                var lines = File.ReadAllLines(filename);

                var rowsCount = int.Parse(lines[0].Split(' ')[0]);
                var columnsCount = int.Parse(lines[0].Split(' ')[1]);

                State.Initialize(rowsCount, columnsCount);

                x = int.Parse(lines[1].Split(' ')[0]);
                y = int.Parse(lines[1].Split(' ')[1]);

                initialState = new State(x, y);

                x = int.Parse(lines[2].Split(' ')[0]);
                y = int.Parse(lines[2].Split(' ')[1]);

                solutionState = new State(x, y);


                for (int i = 0; i < rowsCount; i++)
                    for (int j = 0; j < columnsCount; j++)
                        if (int.Parse(lines[i + 3].Split(' ')[j]) == 1)
                            State.matrix[i, j] = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }
    }
}
