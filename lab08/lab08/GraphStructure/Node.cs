using System;
using System.Collections.Generic;

namespace lab08.GraphStructure
{
    #region NodeComparator

    class NodeComparator : IComparer<Node>
    {
        private List<int> distance;

        public NodeComparator(List<int> distance)
        {
            this.distance = distance;
        }

        public int Compare(Node x, Node y)
        {
            return distance[x.Id] > distance[y.Id] ? 1 : -1;
        }
    }

    #endregion

    class Node
    {
        #region Properties

        public int Id { get; set; }
        public Node Parent { get; set; }
        public string City { get; set; }
        public bool IsVisited { get; set; }

        #endregion

        public Node(string city, int id)
        {
            City = city;
            Id = id;
        }

        public Node(int id)
        {
            City = "";
            Id = id;
        }

        public void Visit()
        {
            IsVisited = true;
        }

        public void Reset()
        {
            IsVisited = false;
        }

        public override string ToString()
        {
            var result = "Node : ";

            if (City.Length != 0)
                String.Concat(result, String.Format("{0}, ", City));

            return String.Format("{0}{1}", result, Id);
        }
    }
}
