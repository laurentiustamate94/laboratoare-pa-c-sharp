using System;
using System.Collections.Generic;

namespace Common
{
    public enum Property
    {
        StronglyConnectedComponent
    }

    public class Node
    {
        #region Properties

        /* Generic property field */
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Dictionary<Property, int> Properties { get; private set; }

        /* DF traversal */
        public int LowLink { get; set; }
        public bool InStack { get; set; }
        public int DiscoveryTime { get; set; }

        /* Bonus */
        public int Sum { get; set; }
        public int ComponentIndex { get; set; }

        #endregion

        public const int UNSET = -1;

        public Node(string name, int id)
        {
            Name = name;
            Id = id;

            Reset();
        }

        public Node(int id)
        {
            Name = String.Empty;
            Id = id;

            Properties = new Dictionary<Property, int>();

            Reset();
        }

        public void Reset()
        {
            InStack = false;
            DiscoveryTime = LowLink = ComponentIndex = UNSET;
            
            if(!Properties.ContainsValue(UNSET))
                Properties.Add(Property.StronglyConnectedComponent, UNSET);
        }

        private bool Visited()
        {
            return DiscoveryTime != UNSET;
        }

        public override string ToString()
        {
            string result = String.Empty;

            if (Name.Length > 0)
                result += Name + ", ";

            result += Id;

            return result;
        }
    }
}

