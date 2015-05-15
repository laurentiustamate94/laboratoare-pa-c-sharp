namespace lab10.GraphStructure
{
    class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Capacity { get; set; }

        public Edge(int firstNode, int secondNode, int capacity)
        {
            FirstNode = firstNode;
            SecondNode = secondNode;
            Capacity = capacity;
        }
    }
}
