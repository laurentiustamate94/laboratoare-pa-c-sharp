using System.Collections.Generic;

using lab08.GraphStructure;

namespace lab08.Tasks
{
    class MinCost
    {
        protected List<int> Distance { get; private set; }
        protected Graph Graph { get; private set; }

        public MinCost(Graph graph)
        {
            Graph = graph;
            Distance = new List<int>(graph.Nodes.Count);

            for (int i = 0; i < graph.Nodes.Count; i++)
                Distance.Add(Graph.MAGIC_NUMBER);
        }

        protected void ResetDistance()
        {
            for (int i = 0; i < Distance.Count; i++)
                Distance.Insert(i, Graph.MAGIC_NUMBER);
        }
    }
}
