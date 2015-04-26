using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Common
{
    public enum GraphType
    {
        Directed,
        Undirected
    }

    public class Graph
    {
        #region Properties

        public GraphType Type { get; private set; }
        public List<Node> Nodes { get; private set; }
        public List<List<Node>> Edges { get; private set; }
        public int Time { get; set; }

        /* Strongly connected components */
        public Stack<Node> NodeStack { get; private set; }
        public List<List<Node>> ConnectedComponents { get; private set; }

        /* Biconnected components */
        public Stack<Pair<Node, Node>> EdgeStack { get; private set; }
        public List<Node> ArticulationPoints { get; private set; }
        public List<Pair<Node, Node>> CriticalVertices { get; private set; }

        #endregion

        public Graph(GraphType type)
        {
            Type = type;

            Nodes = new List<Node>();
            Edges = new List<List<Node>>();

            NodeStack = new Stack<Node>();
            ConnectedComponents = new List<List<Node>>();

            ArticulationPoints = new List<Node>();
            EdgeStack = new Stack<Pair<Node, Node>>();
            CriticalVertices = new List<Pair<Node, Node>>();
        }

        public void InsertEdge(Node first, Node second)
        {
            Edges.ElementAt(first.Id).Add(second);
        }

        public void InsertNode(Node node)
        {
            Nodes.Add(node);
            Edges.Add(new List<Node>());
        }

        public List<Node> GetEdges(Node node)
        {
            return Edges.ElementAt(node.Id);
        }

        public void Reset()
        {
            foreach (var node in Nodes)
                node.Reset();

            NodeStack.Clear();
            ConnectedComponents.Clear();

            ArticulationPoints.Clear();
            CriticalVertices.Clear();

            Time = 0;
        }

        public void PrintStronglyConnectedComponents()
        {
            Console.WriteLine("Strongly Connected Componenets:");
            foreach (var component in ConnectedComponents)
                Console.WriteLine(component);

            Console.WriteLine();
        }

        public override string ToString()
        {
            string result = "Graph:\n";

            foreach (var node in Nodes)
                String.Concat(result, String.Format("{0} : {1}\n", node, Edges.ElementAt(node.Id)));

            return result + "\n";
        }

        public void ReadData(string filename)
        {
            try
            {
                var lines = File.ReadAllLines(filename);

                int nodes = int.Parse(lines[0].Split(' ')[0]);
                int edges = int.Parse(lines[0].Split(' ')[1]);

                for (int i = 0; i < nodes; i++)
                    InsertNode(new Node(i));

                for (int i = 0; i < edges; i++)
                {
                    int firstNode = int.Parse(lines[i + 1].Split(' ')[0]);
                    int secondNode = int.Parse(lines[i + 1].Split(' ')[1]);

                    InsertEdge(Nodes.ElementAt(firstNode), Nodes.ElementAt(secondNode));

                    if (Type == GraphType.Undirected)
                        InsertEdge(Nodes.ElementAt(secondNode), Nodes.ElementAt(firstNode));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }
    }
}
