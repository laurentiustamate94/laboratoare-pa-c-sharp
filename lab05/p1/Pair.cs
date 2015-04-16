using System;

namespace p1
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
