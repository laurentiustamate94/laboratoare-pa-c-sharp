using System;

namespace lab10.GraphStructure
{
    public class Pair
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;

            if (pair == null)
                return false;

            if (!pair.First.Equals(First))
                return false;

            if (!pair.Second.Equals(Second))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            int firstHash = First != null ? First.GetHashCode() : 0;
            int secondHash = Second != null ? Second.GetHashCode() : 0;

            return (firstHash + secondHash) * secondHash + firstHash;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", First, Second);
        }
    }
}
