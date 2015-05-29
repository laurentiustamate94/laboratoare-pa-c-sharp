using System.Collections.Generic;

namespace p2
{
    enum Algorithm
    {
        AStar
    }

    class StateComparator : IComparer<State>
    {
        private Algorithm algorithm;

        public StateComparator(Algorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        private int ComputeFunction(State state)
        {
            /* f(n) = g(n) + h(n) */

            if (algorithm == Algorithm.AStar)
                return state.Distance + state.ApproximateDistance();

            return 0;
        }

        public int Compare(State x, State y)
        {
            return ComputeFunction(x) - ComputeFunction(y);
        }
    }
}
