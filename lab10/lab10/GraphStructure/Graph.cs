using System;
using System.IO;
using System.Collections.Generic;

namespace lab10.GraphStructure
{
    enum GraphType
    {
        Directed,
        Undirected
    }

    class Graph
    {
        #region Properties

        public List<List<int>> Neighbours { get; set; }
        public List<Edge> Edges { get; set; }
        public List<int> Nodes { get; set; }

        public int[] Parents { get; set; }
        public int Size { get; private set; }

        public string Filename { get; private set; }
        public GraphType Type { get; private set; }

        #endregion

        public int[][] flowMatrix;
        public int[][] capacityMatrix;
        public bool[][] adjacencyMatrix;

        const int UNDEFINED = 0;
        const int INFINITY = int.MaxValue;

        public Graph(string filename, GraphType type)
        {
            Type = type;
            Filename = filename;

            ReadData(filename, type);
        }

        public Graph(int size, GraphType type)
        {
            NewEmptyGraph(size, type);
        }

        public void ReloadData()
        {
            ReadData(Filename, Type);
        }

        public List<int> GetNeighbours(int node)
        {
            return Neighbours[node];
        }

        public void AddEdge(int firstNode, int secondNode, int capacity)
        {
            AddEdgeInMatrix(firstNode, secondNode, capacity);

            if (Type == GraphType.Undirected)
                AddEdgeInMatrix(secondNode, firstNode, capacity);
        }

        private void AddEdgeInMatrix(int firstNode, int secondNode, int capacity)
        {
            adjacencyMatrix[firstNode][secondNode] = true;
            capacityMatrix[firstNode][secondNode] = capacity;

            Neighbours[firstNode].Add(secondNode);
            Edges.Add(new Edge(firstNode, secondNode, capacity));
        }

        #region Initialization

        private void NewEmptyGraph(int size, GraphType type)
        {
            Size = size;
            Type = type;

            AllocObjects();

            InitializeAdjacencyMatrix();
            InitializeCapacityMatrix();

            ClearParents();
            ClearFlow();
        }

        private void AllocObjects()
        {
            flowMatrix = new int[Size][];
            capacityMatrix = new int[Size][];
            adjacencyMatrix = new bool[Size][];

            Nodes = new List<int>();
            Parents = new int[Size];
            Edges = new List<Edge>();
            Neighbours = new List<List<int>>();

            for (int i = 0; i < Size; i++)
            {
                flowMatrix[i] = new int[Size];
                capacityMatrix[i] = new int[Size];
                adjacencyMatrix[i] = new bool[Size];

                Nodes.Add(i);
                Neighbours.Add(new List<int>());
            }
        }

        private void InitializeAdjacencyMatrix()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    capacityMatrix[i][j] = UNDEFINED;
        }

        private void InitializeCapacityMatrix()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    capacityMatrix[i][j] = UNDEFINED;
        }

        public void ClearParents()
        {
            for (int i = 0; i < Size; i++)
                Parents[i] = UNDEFINED;
        }

        public void ClearFlow()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    flowMatrix[i][j] = 0;
        }

        #endregion

        #region Output Printing

        public void PrintPathBetween(int firstNode, int lastNode)
        {
            Console.Write("{0} ", firstNode);

            var path = new Stack<int>();
            var currentNode = lastNode;

            do
            {
                path.Push(currentNode);
                currentNode = Parents[currentNode];
            }
            while (currentNode != firstNode);

            while (path.Count > 0)
                Console.Write("{0} ", path.Pop());

            Console.WriteLine();

        }

        public void Print()
        {
            PrintNeighbours();
            PrintAdjacencyMatrix();
            PrintCapacityMatrix();
            PrintFlowMatrix();

            PrintParents();

            PrintEdges();
            PrintNodes();
        }

        public void PrintNeighbours()
        {
            Console.WriteLine("Neighbours list:");

            for (int i = 0; i < Size; i++)
            {
                Console.Write("{0} : ", i);

                foreach (var vertex in Neighbours[i])
                    Console.Write("{0} ", vertex);

                Console.WriteLine();
            }
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Adjacency matrix:");

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write(adjacencyMatrix[i][j] ? "1 " : "0 ");

                Console.WriteLine();
            }
        }

        public void PrintCapacityMatrix()
        {
            Console.WriteLine("Capacity matrix:");

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var output = capacityMatrix[i][j] == UNDEFINED ? "U" : capacityMatrix[i][j].ToString();

                    Console.Write("{0} ", output);
                }

                Console.WriteLine();
            }
        }

        public void PrintFlowMatrix()
        {
            Console.WriteLine("Flow matrix:");

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var output = flowMatrix[i][j] == UNDEFINED ? "U" : flowMatrix[i][j].ToString();

                    Console.Write("{0} ", output);
                }

                Console.WriteLine();
            }
        }

        public void PrintParents()
        {
            Console.WriteLine("Parents:");

            for (int i = 0; i < Size; i++)
            {
                if (Parents[i] == UNDEFINED)
                {
                    Console.WriteLine("{0} : UNDEFINED", i);

                    continue;
                }

                Console.WriteLine("{0} : {1}", i, Parents[i]);
            }
        }

        public void PrintEdges()
        {
            Console.Write("Arcs: ");

            foreach (var edge in Edges)
                Console.Write("({0}, {1}, {2}) ", edge.FirstNode, edge.SecondNode, edge.Capacity);

            Console.WriteLine();
        }

        public void PrintNodes()
        {
            Console.Write("Nodes: ");

            foreach (var node in Nodes)
                Console.Write("{0} ", node);

            Console.WriteLine();
        }

        #endregion

        public bool IsSaturated(int u, int v)
        {
            return capacityMatrix[u][v] == 0 && IsEdge(u, v);
        }

        public bool IsEdge(int u, int v)
        {
            return adjacencyMatrix[u][v];
        }

        public void ReadData(string filename, GraphType type)
        {
            try
            {
                var lines = File.ReadAllLines(filename);

                Size = int.Parse(lines[0]);
                int edgeCount = int.Parse(lines[1]);

                NewEmptyGraph(Size, type);

                for (int i = 0; i < edgeCount; i++)
                {
                    var firstNode = int.Parse(lines[i + 2].Split(' ')[0]);
                    var secondNode = int.Parse(lines[i + 2].Split(' ')[1]);
                    var capacity = int.Parse(lines[i + 2].Split(' ')[2]);

                    AddEdge(firstNode, secondNode, capacity);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }
    }
}
