using System;

namespace p2
{
    class Reversi
    {
        public static int INF = Int32.MaxValue;
        public static int N = 6; // Pastrati N par, N >= 4

        int[,] data;

        public Reversi()
        {
            data = new int[N, N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    data[i, j] = 0;

            data[N / 2 - 1, N / 2 - 1] = data[N / 2, N / 2] = 1;
            data[N / 2 - 1, N / 2] = data[N / 2, N / 2 - 1] = -1;
        }

        /// <summary>
        /// Functia de evaluare a starii curente a jocului
        /// Evaluarea se face din perspectiva jucatorului
        /// aflat curent la mutare (player)
        /// </summary> 
        public int Evaluate(int player)
        {
            /**
             * TODO Implementati o functie de evaluare
             * Aceasta trebuie sa intoarca:
             * INF daca jocul este terminat in favoarea lui player
             * -INF daca jocul este terminat in defavoarea lui player
             *
             * In celelalte cazuri ar trebui sa intoarca un scor cu atat
             * mai mare, cu cat player ar avea o sansa mai mare de castig
             */

            return 0;
        }

        /// <summary>
        /// Intoarce true daca jocul este intr-o stare finala
        /// </summary> 
        public bool HasEnded()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    var tmp = this.Clone();

                    if (tmp.ApplyMove(new Move(1, i, j)))
                        return false;

                    tmp = this.Clone();

                    if (tmp.ApplyMove(new Move(-1, i, j)))
                        return false;
                }

            return true;
        }

        /// <summary>
        /// Aplica o mutare a jucatorului, modificand starea jocului
        /// Plaseaza piesa jucatorului move.player in pozitia move.CoordX, move.CoordY
        /// Mutarea move.CoordX == -1, move.CoordY == -1 semnifica ca jucatorul
        /// paseaza randul la mutare
        /// Returneaza true daca mutarea este valida
        /// </summary> 
        public bool ApplyMove(Move move)
        {
            if (move.CoordX == -1 && move.CoordY == -1)
                return true;

            if (data[move.CoordX, move.CoordY] != 0)
                return false;

            var ok = false;

            for (int xDir = -1; xDir <= 1; xDir++)
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                        continue;

                    var i = move.CoordX + xDir;
                    var j = move.CoordY + yDir;

                    for (; CanContinue(-move.Player, i, j); i += xDir, j += yDir) ;

                    if (CanContinue(move.Player, i, j)
                        && (Math.Abs(move.CoordX - i) > 1 || Math.Abs(move.CoordY - j) > 1))
                    {
                        ok = true;

                        for (i = move.CoordX + xDir, j = move.CoordY + yDir;
                            CanContinue(-move.Player, i, j); i += xDir, j += yDir)
                            data[i, j] = move.Player;
                    }
                }

            if (!ok)
                return false;

            data[move.CoordX, move.CoordY] = move.Player;

            return true;
        }

        private bool CanContinue(int player, int i, int j)
        {
            return i >= 0 && j >= 0 && i < N && j < N && data[i, j] == player;
        }

        /// <summary>
        /// Intoarce 1 daca jucatorul a castigat, 
        /// 0 daca este remiza si -1 daca jucatorul a pierdut
        /// </summary> 
        public int IsWinner(int player)
        {
            if (!HasEnded())
                return 0;

            var sum = 0;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (data[i, j] == player)
                        sum++;
                    else if (data[i, j] == -player)
                        sum--;

            if (sum > 0)
                return 1;

            return sum == 0 ? 0 : -1;
        }

        /// <summary>
        /// Afiseaza starea jocului
        /// </summary> 
        public override string ToString()
        {
            var result = "";

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (data[i, j] == 0)
                        result += ".";
                    else if (data[i, j] == 1)
                        result += "O";
                    else
                        result += "X";

                    result += " ";
                }

                result += "\n";
            }

            return result + "\n";
        }

        /// <summary>
        /// Intoarce o copie a starii de joc
        /// </summary> 
        public Reversi Clone()
        {
            var result = new Reversi();

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    result.data[i, j] = data[i, j];

            return result;
        }
    }
}
