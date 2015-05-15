using System;
using System.Collections.Generic;

using lab08.Tasks;
using lab08.GraphStructure;

namespace lab08
{
    class Program
    {
        #region Problem configuration

        const string START_LABEL = "Bucuresti";
        const string END_LABEL = "Paris";

        static string[] dataSets = new string[]
        { 
            "Resources/date1.in", /* graph with positive edges */
            "Resources/date2.in", /* graph with negative edges, Dijkstra should fail */
            "Resources/date2.in"  /* graph with negative cycle */
        };

        public enum Task
        {
            RoyFloyd,
            Dijkstra,
            BellmanFord
        }

        #endregion

        const int CURRENT_DATASET_INDEX = 0;
        const Task CURRENT_TASK = Task.RoyFloyd;

        static void Main(string[] args)
        {
            var graph = new Graph(dataSets[CURRENT_DATASET_INDEX]);
            var source = graph.NodeMap[START_LABEL];
            var destination = graph.NodeMap[END_LABEL];

            switch (CURRENT_TASK)
            {
                case Task.RoyFloyd:
                    {
                        var solver = new RoyFloyd(graph.Nodes.Count);

                        solver.Run(graph);
                        solver.PrintMinPath(graph, source, destination);

                        break;
                    }

                case Task.Dijkstra:
                    {
                        var solver = new Dijkstra(graph);
                        var distance = solver.Run(source);

                        PrintDistance(graph, distance);

                        break;
                    }

                case Task.BellmanFord:
                    {
                        var solver = new BellmanFord(graph);
                        var distance = solver.Run(source);

                        PrintDistance(graph, distance);

                        break;
                    }

                default: break;
            }
        }

        static void PrintDistance(Graph graph, List<int> distance)
        {
            Console.WriteLine("Result: ");

            for (int i = 0; i < graph.Nodes.Count; ++i)
                Console.WriteLine("{0}, {1}", graph.Nodes[i].City, distance[i]);
        }
    }
}
