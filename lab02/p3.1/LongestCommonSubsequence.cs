using System;
using System.Collections.Generic;
using System.IO;

namespace p3._1
{
    class LongestCommonSubsequence
    {
        const int NO_TESTS = 2;

        int[][] s1 = new int[NO_TESTS][];
        int[][] s2 = new int[NO_TESTS][];

        private int[] LCS(int[] s1, int[] s2)
        {
            int[] rez;
            int[,] list = new int[s1.Length, s2.Length];

            /* Bordam marginea de sus si marginea din stanga a lui list
             * adica vom calcula lungimea maxima pentru prima litera din s1 si toate subsirurile lui s2,
             * respectiv prima litera din s2 si toate subsirurile lui s1,
             * pentru a scrie o formula de recurenta mai usoara
             */

            for (int is1 = 0; is1 < s1.Length; is1++)
            {
                if (s1[is1] == s2[0])
                    list[is1, 0] = 1;

                // else it's by default 0
            }

            for (int is2 = 0; is2 < s2.Length; is2++)
            {
                if (s2[is2] == s1[0])
                    list[0, is2] = 1;

                // else it's by default 0
            }

            // TODO (1) calculam lungimea pentru toate celelalte elemente din list

            int len = list[s1.Length - 1, s2.Length - 1];
            rez = new int[len];

            int k = 0;

            // TODO (2) reconstituim subsirul in rez

            int[] clone = (int[])rez.Clone();

            return rez;
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

                    s1[i] = new int[n];
                    for (j = 0; j < n; j++)
                        s1[i][j] = int.Parse(lines[i * 4 + 1].Split(' ')[j]);

                    n = int.Parse(lines[i * 4 + 2]);

                    s2[i] = new int[n];
                    for (j = 0; j < n; j++)
                        s2[i][j] = int.Parse(lines[i * 4 + 3].Split(' ')[j]);
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
                int[] rez = LCS(s1[i], s2[i]);

                Console.WriteLine("Cel mai lung subsir comun intre {0} si {1} este {2}",
                    GetOutput(s1[i]), GetOutput(s2[i]), GetOutput(rez));
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
