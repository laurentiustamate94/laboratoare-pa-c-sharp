using System;

namespace p13
{
    class GuessMe
    {
        int unknown;
        const int MAX_VALUE = 424242; // Magic constant is magic
		
		private bool IsInBounds(int x)
        {
            return x <= unknown;
        }

        public void SetUnknown(int u)
        {
            unknown = u;
        }

        public int Guess()
        {
            int lower = 0;
            int upper = MAX_VALUE;
            int res = 0;

            /* TODO Folosind metoda isInBounds cautati binar
             * cea mai mare valoare pentru care isInBounds intoarce true.
             * Vom denumi acea valoare unknown. Se stie ca isInBounds
             * intoarce true de la 0 la unknown si false pentru numere mai mari
             * decat unknown:
             *
             * Exemplu, unknown = 4
             *    _________
             * f:          |_______
             * x: 0 1 2 3 4 5 6 7 8
             *
             * Remember! (lower + upper) / 2 is bad!
             */

            return res;
        }
    }
}
