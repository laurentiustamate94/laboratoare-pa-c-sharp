using System;
using System.IO;
using System.Collections.Generic;

namespace lab08.GraphStructure
{
    class Graph
    {
        public List<Node> Nodes { get; private set; }
        public List<List<Pair<Node, int>>> Edges { get; private set; }
        public Dictionary<string, Node> NodeMap { get; private set; }

        /* magic number is magic */
        public const int MAGIC_NUMBER = 424242;

        public Graph(string filename)
        {
            Nodes = new List<Node>();
            Edges = new List<List<Pair<Node, int>>>();
            NodeMap = new Dictionary<string, Node>();

            ReadData(filename);
        }

        public bool ExistsEdgeBetween(Node node1, Node node2)
        {
            var edges = Edges[node1.Id];

            for (int i = 0; i < edges.Count; i++)
                if (edges[i].First.Id == node2.Id)
                    return true;

            return false;
        }

        public int GetCostBetween(Node node1, Node node2)
        {
            var edges = Edges[node1.Id];

            for (int i = 0; i < edges.Count; i++)
                if (edges[i].First.Id == node2.Id)
                    return edges[i].Second;

            return MAGIC_NUMBER;
        }

        public Node GetNode(string city)
        {
            return NodeMap[city];
        }

        public List<Pair<Node, int>> GetEdges(Node node)
        {
            return Edges[node.Id];
        }

        public void InsertNode(Node node)
        {
            Nodes.Add(node);
            Edges.Add(new List<Pair<Node, int>>());

            RegisterNode(node);
        }

        public void InsertEdge(Node firstNode, Node secondNode, int cost)
        {
            Edges[firstNode.Id].Add(new Pair<Node, int>(secondNode, cost));
        }

        private void RegisterNode(Node node)
        {
            NodeMap.Add(node.City, node);
        }

        public void Reset()
        {
            foreach (var node in Nodes)
                node.Reset();
        }

        public void ClearGraph()
        {
            Nodes.Clear();
            Edges.Clear();
            NodeMap.Clear();
        }

        public void ReadData(string filename)
        {
            ClearGraph();

            try
            {
                var lines = File.ReadAllLines(filename);

                int nodes = int.Parse(lines[0]);

                for (int i = 0; i < nodes; i++)
                    InsertNode(new Node(lines[i + 1], i));

                int edges = int.Parse(lines[nodes + 1]);
                int node1, node2, cost;

                for (int i = 0; i < edges; i++)
                {
                    node1 = int.Parse(lines[nodes + 1 + i + 1].Split(' ')[0]);
                    node2 = int.Parse(lines[nodes + 1 + i + 1].Split(' ')[1]);
                    cost = int.Parse(lines[nodes + 1 + i + 1].Split(' ')[2]);

                    InsertEdge(Nodes[node1], Nodes[node2], cost);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }

        public override string ToString()
        {
            var result = "Print Graph:\n";

            foreach (var node in Nodes)
            {
                String.Concat(result, String.Format("OutEdges for {0} -> ", node));

                foreach (var edge in GetEdges(node))
                    String.Concat(result, String.Format("{0} ( {1} ) |", edge.First.City, edge.Second));

                String.Concat(result, "\n");
            }

            return String.Format("{0}\n", result);
        }
    }
}
