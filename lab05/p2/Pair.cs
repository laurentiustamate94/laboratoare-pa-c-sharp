using System;

namespace p2
{
    class Pair<F, S>
    {
        public F First { get; set; }
        public S Second { get; set; }

        public Pair(F first, S second)
        {
            First = first;
            Second = second;
        }
    }
}
