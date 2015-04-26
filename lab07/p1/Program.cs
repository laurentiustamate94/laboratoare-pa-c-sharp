using System;
using System.Linq;
using System.Collections.Generic;

using Common;

namespace p1
{
    class Program
    {
        const int NO_TESTS = 4;

        static void DoDFS(Graph graph, Node node)
        {
            /*
             * TODO: Initializeaza level si lowlink
             */

            /*
             * TODO: Adauga nodul in stiva
             */

            /*
             * TODO: Parcurgere DF pentru fiecare vecin nevizitat
             */

            /*
             * TODO: Salveaza componenta tare conexa curenta
             */
        }

        static void StronglyConnectedComponents(Graph graph)
        {
            graph.Reset();

            /*
             * TODO: Apeleaza dfs_ctc pentru fiecare nod nevizitat.
             */

            graph.PrintStronglyConnectedComponents();

            return;
        }

        /*
         * HINT: In urma compactarii grafului original
         * rezulta tot un graf orientat, fara cicluri.
         */

        static void DoBonus(Graph graph)
        {
            if (graph.ConnectedComponents.Count == 0)
                StronglyConnectedComponents(graph);

            /*
             * Construim un nou graf 'condensand' 
             * componentele tare conexe intr-un singur nod.
             */

            var cluster = new Graph(GraphType.Directed);

            for (int i = 0, size = graph.ConnectedComponents.Count; i < size; i++)
                cluster.InsertNode(new Node(i));

            var allClusters = cluster.Nodes;

            CreateNewCondensedGraph(graph, cluster, allClusters);

            Console.WriteLine("Graful rezultat in urma compactarii: ");
            Console.WriteLine(cluster);

            /*
             * TODO: Calculeaza numarul maxim de jucatori daca s-ar adauga o legatura artificiala
             * Complexitate solutie: O( N + M )
             * N - numarul de noduri din graful comprimat
             * M - numarul de muchii  
             */

            Console.WriteLine("Daca s-ar adauga o legatura artificiala, numarul maxim de jucatori ");
        }

        private static void CreateNewCondensedGraph(Graph graph, Graph cluster, List<Node> allClusters)
        {
            for (int i = 0, size = graph.ConnectedComponents.Count; i < size; i++)
            {
                // nodurile care alcatuiesc componenta conexa curenta
                var innerNodes = graph.ConnectedComponents.ElementAt(i);

                // avoid duplicate edges

                var connections = new HashSet<int>();

                // pentru fiecare nod..
                foreach (var node in innerNodes)
                {
                    var edges = graph.GetEdges(node);

                    // pentru fiecare muchie..
                    foreach (var vertex in edges)
                    {
                        int componentsIndex;

                        vertex.Properties.TryGetValue(Property.StronglyConnectedComponent, out componentsIndex);

                        if (componentsIndex != i && !connections.Contains(componentsIndex))
                        {
                            cluster.InsertEdge(allClusters.ElementAt(i), allClusters.ElementAt(componentsIndex));
                            connections.Add(componentsIndex);
                        }
                    }
                }

                //Console.WriteLine(innerNodes);
                allClusters.ElementAt(i).Sum = innerNodes.Count;
            }
        }

        static void Main(string[] args)
        {
            int testCount = 0;

            while (testCount++ < NO_TESTS)
            {
                Graph graph = new Graph(GraphType.Undirected);

                graph.ReadData("Resources/date.in");

                Console.WriteLine(graph);

                StronglyConnectedComponents(graph);
                //DoBonus(graph);

                Console.WriteLine("###########################");
            }
        }
    }
}
