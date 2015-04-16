using System;

namespace p1
{
    class Move
    {
        public int Amount { get; set; }
        public int Heap { get; set; }

        public Move(int amount, int heap)
        {
            Amount = amount;
            Heap = heap;
        }

        public Move()
            : this(0, -1)
        {
            //NaN
        }
    }
}
