using System.Collections.Generic;

using lab08.GraphStructure;

namespace lab08.Tasks
{
    class BellmanFord : MinCost
    {

        public BellmanFord(Graph graph)
            : base(graph)
        {
        }

        public List<int> Run(Node source)
        {

            int nodeCount = Graph.Nodes.Count;

            /* 
             * TODO
             * 
             * Given a graph with either positive or negative cost edges,
             * compute the distance from a source node to every other node
             * using the classic BellmanFord implementation. [3p]
             */

            CheckNegativeCycle();

            return Distance;
        }

        public void CheckNegativeCycle()
        {
            /*
             * TODO
             * 
             * Check if there exists a negative cycle and
             * print such a cycle if it exists. [1p]
             */
        }
    }
}
