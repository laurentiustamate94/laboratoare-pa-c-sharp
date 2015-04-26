using System;
using System.Linq;
using System.Collections.Generic;

using Common;

namespace p2
{
    class Program
    {
        const int NO_TESTS = 3;

        static void DoDFSBiconnected(Graph graph, Node node, int fatherId)
        {
            /*
             * TODO: Initializati level si lowlink
             */

            /*
             * TODO: Identifica daca nodul este punct de articulatie
             */
        }

        static void BiconnectedComponents(Graph graph)
        {
            graph.Reset();

            /*
             * TODO: Parcurgere df pentru identificarea componentelor biconexe
             */

            Console.WriteLine("\nPuncte de articulatie: \n" + graph.ArticulationPoints);
            Console.WriteLine("\nMuchii critice: \n" + graph.CriticalVertices);
        }

        static void printBiconexComponent(Graph graph, Node firstNode, Node secondNode)
        {
            Console.WriteLine("Componenta biconexa: ");

            Pair<Node, Node> aux;
            var components = new HashSet<Node>();

            do
            {
                aux = graph.EdgeStack.Pop();
                components.Add(aux.First);
                components.Add(aux.Second);
            }
            while (aux.First != firstNode || aux.Second != secondNode);

            Console.WriteLine(components);
        }

        static void Main(string[] args)
        {
            int testCount = 0;

            while (testCount++ < NO_TESTS)
            {
                var graph = new Graph(GraphType.Undirected);

                graph.ReadData("date.in");

                Console.WriteLine(graph);

                BiconnectedComponents(graph);
            }
        }
    }
}
