using System;
using System.Collections.Generic;

namespace p2
{
    class Program
    {
        static State initialState = new State(new int[]{3, 3, 0, 0}, BoatPosition.East, null, 0);
        static State solutionState = new State(new int[]{0, 0, 3, 3}, BoatPosition.West, null, 0);

        static void Main(string[] args)
        {
            var open = new SortedSet<State>(new StateComparator(Algorithm.AStar));

            /* Initial doar nodul de start este in curs de explorare */
            open.Add(initialState);

            /* Pentru nodurile care au fost deja expandate. */
            var closed = new List<State>();

            /* Numar pasi pana la solutie */
            int steps = 0;

            /* TODO: A* */

            Console.WriteLine("Number of steps until solution: {0}", steps);
        }
    }
}
