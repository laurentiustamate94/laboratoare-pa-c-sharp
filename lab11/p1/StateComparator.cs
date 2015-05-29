using System.Collections.Generic;

namespace p1
{
    enum Algorithm
    {
        AStar,
        BestFirst
    }

    class StateComparator : IComparer<State>
    {
        private Algorithm algorithm;
        private State solutionState;

        public StateComparator(Algorithm algorithm, State solutionState)
        {
            this.algorithm = algorithm;
            this.solutionState = solutionState;
        }

        private int ComputeFunction(State state)
        {
            /* f(n) = g(n) + h(n) */

            if (algorithm == Algorithm.BestFirst)
                return state.ApproximateDistance(solutionState);

            if (algorithm == Algorithm.AStar)
                return state.Distance + state.ApproximateDistance(solutionState);

            return 0;
        }

        public int Compare(State x, State y)
        {
            return ComputeFunction(x) - ComputeFunction(y);
        }
    }
}
