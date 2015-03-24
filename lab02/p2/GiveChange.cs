using System;
using System.Collections.Generic;
using System.IO;

namespace p2
{
    class GiveChange
    {
        const int NO_TESTS = 2;

        int[][] B = new int[NO_TESTS][]; // lista de bancnote pentru fiecare test
        int[][] x = new int[NO_TESTS][]; // lista de resturi pentru fiecare test

        private int[] ChangeGreedy(int x, int[] B)
        {
            List<int> rest = new List<int>();

            /* TODO: folositi Greedy pentru a determina forma restului
             * presupunem ca B este ordonat descrescator 
             */

            return rest.ToArray();
        }

        private int[] ChangePD(int x, int[] B)
        {
            List<int> rest = new List<int>();

            int[] C = new int[x + 1]; // C[p] = numarul minim de bancnote pt restul p
            int[] S = new int[x + 1]; // S[p] = indicele urmatoarei bancnote pt restul p

            /* Folositi PD pentru a determina forma restului
		     * presupunem ca B este ordonat descrescator 
             */

            int[] B_cresc = new int[B.Length];

            // TODO (a) ordonam B crescator in B_cresc


            /* TODO (b) completam C[p] = numarul minim de bancnote necesare pentru a da restul p
             * si S[p] = indexul urmatoarei monede necesare pentru a da restul p
             * pentru fiecare p intre 0 si x
             */


            // TODO (c) reconstruim solutia pe baza lui C si a lui S


            return rest.ToArray();
        }

        public void ReadData(string filename)
        {
            try
            {
                int n, i, j;

                var lines = File.ReadAllLines(filename);

                for (i = 0; i < NO_TESTS; i++)
                {
                    n = int.Parse(lines[i * 4]);

                    B[i] = new int[n];
                    for (j = 0; j < n; j++)
                        B[i][j] = int.Parse(lines[i * 4 + 1].Split(' ')[j]);

                    n = int.Parse(lines[i * 4 + 2]);

                    x[i] = new int[n];
                    for (j = 0; j < n; j++)
                        x[i][j] = int.Parse(lines[i * 4 + 3].Split(' ')[j]);
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
                Console.WriteLine("Setul de bancnote este {0}", GetOutput(B[i]));

                foreach (var rest in x[i])
                {
                    Console.WriteLine("Folosind Greedy, {0} se da {1}",
                        rest, GetOutput(ChangeGreedy(rest, B[i])));


                    Console.WriteLine("Folosind PD, {0} se da {1}",
                        rest, GetOutput(ChangePD(rest, B[i])));
                }

                Console.WriteLine();
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
