using System;
using System.Collections.Generic;

using lab08.GraphStructure;

namespace lab08.Tasks
{
    class RoyFloyd
    {
        int[][] cost;
        Node[][] detour;

        public RoyFloyd(int nodeCount)
        {
            cost = new int[nodeCount][];
            detour = new Node[nodeCount][];
        }

        ///<summary>
        /// Matrix for cost
        /// - cost[i][j] - minimum cost for a path from node i to node j
        /// 
        /// Matrix for detour
        /// - detour[i][j] - the "next" node on the path from node i to node j
        ///</summary>
        ///
        ///<param name="graph">The directed graph</param>
        ///
        ///<remarks>
        /// Debugging: dumpCostMatrix();
        /// 
        /// Don't forget to initialize the cost and detour matrixes !!
        ///</remarks>
        public void Run(Graph graph)
        {

            ResetCostMatrix();
            ResetDetourMatrix();

            List<Node> nodes = graph.Nodes;
            int nodeCount = graph.Nodes.Count;

            /*
             * TODO
             * 
             * Given a graph with either positive or negative cost edges,
             * compute the minimum path cost between every node as well
             * as the 'next-hop' node for every such node. [3p]
             * 
             * Don't forget to initialize the cost and detour matrixes !!
             */
        }

        public void PrintMinPath(Graph graph, Node firstNode, Node secondNode)
        {
            Console.Write("Best route between ");
            Console.WriteLine("{0} and {1}", firstNode.City, secondNode.City);

            graph.Reset();
            firstNode.Visit();

            /*
             * TODO
             * 
             * Print the path with minimum cost between two given
             * nodes, based on the detour matrix computed previously [1p]
             * 
             * 
             * HINT
             * 
             * You may use GetNextNode() to retrieve the "next" node
             * on the path from firstNode to secondNode.
             */

            Console.WriteLine("Total cost: {0}", cost[firstNode.Id][secondNode.Id]);
        }

        private Node GetNextNode(Graph graph, Node firstNode, Node secondNode)
        {
            if (firstNode.Id == secondNode.Id)
                throw new Exception(String.Format("Path from node {0} to itself requested", firstNode.City));

            Node pivot = detour[firstNode.Id][secondNode.Id];
            if (pivot == null)
                throw new Exception(String.Format("No path connects {0} to {1}", firstNode.City, secondNode.City));

            if (pivot.IsVisited)
                throw new Exception("Cycle Detected");

            pivot.Visit();

            return pivot;
        }

        public void DumpCostMatrix()
        {
            for (int i = 0; i < cost.Length; i++)
            {
                for (int j = 0; j < cost[i].Length; j++)
                    Console.Write(cost[i][j] + " ");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void ResetCostMatrix()
        {
            if (cost[0] == null)
                throw new Exception("You forgot to initialize the cost matrix !!");

            for (int i = 0; i < cost.Length; i++)
                for (int j = 0; j < cost[i].Length; j++)
                    cost[i][j] = Graph.MAGIC_NUMBER;
        }

        public void ResetDetourMatrix()
        {
            if (detour[0] == null)
                throw new Exception("You forgot to initialize the detour matrix !!");

            for (int i = 0; i < detour.Length; i++)
                for (int j = 0; j < detour[i].Length; j++)
                    detour[i][j] = null;
        }
    }
}
