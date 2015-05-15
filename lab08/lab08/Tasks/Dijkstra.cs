using System.Collections.Generic;

using lab08.GraphStructure;

namespace lab08.Tasks
{
    class Dijkstra : MinCost
    {
        public Dijkstra(Graph graph)
            : base(graph)
        {
        }

        public List<int> Run(Node source)
        {
            ResetDistance();
            int nodeCount = Graph.Nodes.Count;

            var queue = new SortedSet<Node>(new NodeComparator(Distance));

            /* 
             * TODO
             * 
             * Given a graph, with positive cost edges, compute the distance
             * from a source node to every other node using the Dijkstra algorithm. [3p]
             */

            return new List<int>();
        }
    }
}
