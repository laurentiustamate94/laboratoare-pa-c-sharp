using System;

namespace p2
{
    class Program
    {
        static Pair<int, Move> Minimax(Reversi init, int player, int depth)
        {
            /**
             * TODO Implementati conditia de oprire
             */

            /**
             * TODO Determinati mutarile posibile
             * si determinati cel mai bun scor si cea mai buna mutare
             * folosind algoritmul minimax
             *
             * Fiti atenti ca daca player nu poate efectua nici o mutare, el
             * poate ceda randul la mutat prin mutarea conventionala <player, -1, -1>
             */

            return new Pair<int, Move>(-Reversi.INF, new Move(player));
        }

        /// <summary>
        /// Implementarea de negamax cu alpha-beta pruning
        /// Intoarce o pereche <x, y> unde x este cel mai bun scor
        /// care poate fi obtinut de jucatorul aflat la mutare,
        /// iar y este mutarea propriu-zisa
        /// </summary> 
        static Pair<int, Move> MinimaxABeta(Reversi init, int player, int depth, int alfa, int beta)
        {
            /**
             * TODO Implementati conditia de oprire
             */

            /**
             * TODO Determinati mutarile posibile
             * si determinati cel mai bun scor si cea mai buna mutare
             * folosind algoritmul minimax cu alfa-beta pruning
             *
             * Fiti atenti ca daca player nu poate efectua nici o mutare, el
             * poate ceda randul la mutat prin mutarea conventionala <player, -1, -1>
             */

            return new Pair<int, Move>(-Reversi.INF, new Move(player));
        }

        static void Main(string[] args)
        {
            var reversi = new Reversi();

            Console.WriteLine(reversi);

            bool HUMAN_PLAYER = true;
            int player = 1;

            while (!reversi.HasEnded())
            {
                if (player == 1)
                {
                    var p = Minimax(reversi, player, 6);
                    //p = minimax_abeta(rev, player, 9, -Inf, Inf);

                    Console.WriteLine("Player {0} evaluates to {1}", player, p.First);
                    reversi.ApplyMove(p.Second);

                    Console.WriteLine(reversi);
                    player *= -1;

                    continue;
                }

                if (!HUMAN_PLAYER)
                {
                    var p = Minimax(reversi, player, 6);
                    //p = minimax_abeta(rev, player, 9, -Inf, Inf);

                    Console.WriteLine("Player {0} evaluates to {1}", player, p.First);
                    reversi.ApplyMove(p.Second);
                    Console.WriteLine(reversi);

                    player *= -1;

                    continue;
                }

                var valid = false;
                while (!valid)
                {
                    Console.Write("Insert position [0..N - 1], [0..N - 1] ");

                    int x = int.Parse(Convert.ToChar(Console.Read()).ToString());
                    int y = int.Parse(Convert.ToChar(Console.Read()).ToString());

                    valid = reversi.ApplyMove(new Move(player, x, y));
                }

                Console.WriteLine(reversi);

                player *= -1;
            }

            var w = reversi.IsWinner(1);

            if (w == 1)
                Console.WriteLine("Player {0} WON!", player);
            else if (w == 0)
                Console.WriteLine("DRAW!");
            else
                Console.WriteLine("Player {0} LOST!", player);
        }
    }
}
