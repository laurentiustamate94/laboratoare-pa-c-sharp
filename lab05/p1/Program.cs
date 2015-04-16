using System;

namespace p1
{
    class Program
    {
        /// <summary>
        /// Implementarea algoritmului minimax (negamax)
        /// Intoarce o pereche <x, y> unde x este cel mai bun scor
        /// care poate fi obtinut de jucatorul aflat la mutare,
        /// iar y este mutarea propriu-zisa
        /// </summary> 
        public static Pair<int, Move> Minimax(Nim init, int player, int depth)
        {
            /**
             * TODO Implementati conditia de oprire
             */

            var moves = init.GetMoves(player);

            /**
             * TODO Determinati cel mai bun scor si cea mai buna mutare
             * folosind algoritmul minimax
             */

            return new Pair<int, Move>(-Nim.INF, new Move());
        }

        /// <summary>
        /// Implementarea de negamax cu alpha-beta pruning
        /// Intoarce o pereche <x, y> unde x este cel mai bun scor
        /// care poate fi obtinut de jucatorul aflat la mutare,
        /// iar y este mutarea propriu-zisa
        /// </summary> 
        public static Pair<int, Move> MinimaxABeta(Nim init, int player, int depth, int alfa, int beta)
        {
            /**
             * TODO Implementati conditia de oprire
             */

            var moves = init.GetMoves(player);

            /**
             * TODO Determinati cel mai bun scor si cea mai buna mutare
             * folosind algoritmul minimax cu alfa-beta pruning
             */

            return new Pair<int, Move>(-Nim.INF, new Move());
        }

        static void Main(string[] args)
        {
            var nim = new Nim();

            nim.heaps[0] = 5;
            nim.heaps[1] = 10;
            nim.heaps[2] = 20;

            Console.WriteLine(nim);

            bool HUMAN_PLAYER = true;
            int player = 1;

            while (!nim.HasEnded())
            {
                if (player == 1)
                {
                    var p = Minimax(nim, player, 6);
                    //p = minimax_abeta(nim, player, 13, -Nim.Inf, Nim.Inf);

                    Console.WriteLine("Player {0} evaluates to {1}", player, p.First);

                    nim.ApplyMove(p.Second);

                    Console.WriteLine(nim);

                    player *= -1;

                    continue;
                }

                if (!HUMAN_PLAYER)
                {
                    var p = Minimax(nim, player, 6);
                    //p = minimax_abeta(nim, player, 13, -Inf, Inf);

                    Console.WriteLine("Player {0} evaluates to {1}", player, p.First);
                    nim.ApplyMove(p.Second);

                    Console.WriteLine(nim);

                    player *= -1;

                    continue;
                }

                var valid = false;

                while (!valid)
                {
                    Console.Write("Insert amount [1, 2 or 3] and heap [0, 1 or 2]: ");

                    int amount = int.Parse(Convert.ToChar(Console.Read()).ToString());
                    int heap = int.Parse(Convert.ToChar(Console.Read()).ToString());

                    valid = nim.ApplyMove(new Move(amount, heap));
                }

                Console.WriteLine(nim);

                player *= -1;
            }

            var w = nim.heaps[0] + nim.heaps[1] + nim.heaps[2];

            if (w == 0)
                Console.WriteLine("Player {0} WON!", player);
            else
                Console.WriteLine("Player {0} LOST!", player);
        }
    }
}
