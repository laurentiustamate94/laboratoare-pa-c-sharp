using System;
using System.IO;

namespace p3._2
{
    class LongestPalindromeSubstring
    {
        const int NO_TESTS = 3;

        int[][] v = new int[NO_TESTS][];

        private int[] LPS(int[] v)
        {
            int n = v.Length;               // lungimea vectorului de intrare
            bool[,] list = new bool[n, n];  // list[i][j] = 1 cand de la i la j avem palindrom
            int max_len = 1;                // lungimea celei mai mari subsecvente palindrom
            int max_poz = 0;                // pozitia la care incepe subsecventa palindrom
            int[] sol;                      // subsecventa propriu-zisa

            /* (1) folosim Programare Dinamica pentru a completa list 
             * in acelasi timp actualizam max_len si max_poz
             */

            // TODO (1.1) calculam L pentru siruri de lungime 1


            // TODO (1.2) calculam L pentru siruri de lungime 2


            /* TODO (1.3) calculam L pentru siruri de lungime cel putin 3
             * hint: vom folosi o formula recursiva ce foloseste elemente calculate anterior
             */


            sol = new int[max_len];

            /*TODO (2) reconstruim subsecventa in sol */


            return sol;
        }

        public void ReadData(string filename)
        {
            try
            {
                int n, i, j;

                var lines = File.ReadAllLines(filename);

                for (i = 0; i < NO_TESTS; i++)
                {
                    /* read the array in which to look for data */
                    n = int.Parse(lines[i * 2]);

                    v[i] = new int[n];
                    for (j = 0; j < n; j++)
                        v[i][j] = int.Parse(lines[i * 2 + 1].Split(' ')[j]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }

        public void Test()
        {
            for (int i = 0; i < NO_TESTS; i++)
            {
                int[] rez = LPS(v[i]);

                Console.WriteLine("In vectorul {0} cea mai mare subsecventa palindrom este {1}",
                    GetOutput(v[i]), GetOutput(rez));
            }
        }

        private string GetOutput(int[] v)
        {
            string output = "{ ";

            foreach (int item in v)
                output += item + " ";

            return output + "}";
        }
    }
}
