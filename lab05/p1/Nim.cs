using System;
using System.Collections.Generic;

namespace p1
{
    class Nim
    {
        public static int INF = Int32.MaxValue;

        public int[] heaps = new int[3];

        public Nim()
        {
            heaps[0] = 3;
            heaps[1] = 4;
            heaps[2] = 5;
        }

        /// <summary>
        /// Returneaza o lista cu mutarile posibile care pot fi efectuate de player
        /// </summary> 
        public List<Move> GetMoves(int player)
        {
            var moves = new List<Move>();

            for (int i = 0; i < 3; i++)
                for (int k = 1; k <= 3; k++)
                    if (k <= heaps[i])
                        moves.Add(new Move(k, i));

            return moves;
        }

        /// <summary>
        /// Intoarce true daca jocul este intr-o stare finala
        /// </summary> 
        public bool HasEnded()
        {
            /**
             * TODO Determinati daca jocul s-a terminat
             */

            return false;
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
             * pentru starea curenta a jocului
             *
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
        /// Aplica o mutarea a jucatorului asupra starii curente
        /// Returneaza false daca mutarea e invalida
        /// </summary> 
        public bool ApplyMove(Move move)
        {
            /**
             * TODO Realizati efectuarea mutarii
             * (scadeti move.Amount din multimea corespunzatoare)
             */

            return false;
        }

        /// <summary>
        /// Returneaza true daca jucatorul a castigat
        /// </summary> 
        bool IsWinner(int player)
        {
            if (!HasEnded())
                return false;

            int sum = 0;

            for (int i = 0; i < 3; i++)
                sum += heaps[i];

            return sum == 0;
        }

        /// <summary>
        /// Afiseaza starea jocului
        /// </summary> 
        public override string ToString()
        {
            var result = "";

            for (int i = 0; i < 3; i++)
            {
                result += i + ":";

                for (int j = 0; j < heaps[i]; j++)
                    result += " *";

                result += "\n";
            }

            result += "\n";

            return result;
        }

        /// <summary>
        /// Returneaza o copie a starii de joc
        /// </summary> 
        public Nim Clone()
        {
            var clone = new Nim();

            for (int i = 0; i < 3; i++)
                clone.heaps[i] = heaps[i];

            return clone;
        }
    }
}
