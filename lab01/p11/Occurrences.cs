using System;
using System.IO;

namespace p11
{
    class Occurrences
    {
        const int NO_TESTS = 2;

        int[][] haystacks = new int[NO_TESTS][];
        int[][] needles = new int[NO_TESTS][];

        private int Count(int[] v, int key, int lower, int upper)
        {
            /* TODO
             * Calculati recursiv numarul de aparitii ale lui key in v
             * intre pozitiile lower si upper.
             * La calcularea pozitiei de mijloc folositi
             *         int m = lower + (upper - lower) / 2;
             * pentru a evita overflow la adunarea pe numere intregi.
             */

            return 0;
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

                    haystacks[i] = new int[n];
                    for (j = 0; j < n; j++)
                        haystacks[i][j] = int.Parse(lines[i * 4 + 1].Split(' ')[j]);

                    n = int.Parse(lines[i * 4 + 2]);

                    needles[i] = new int[n];
                    for (j = 0; j < n; j++)
                        needles[i][j] = int.Parse(lines[i * 4 + 3].Split(' ')[j]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }

        public void Test()
        {
            int occurrences;

            for (int i = 0; i < NO_TESTS; i++)
                foreach (int needle in needles[i])
                {
                    occurrences = Count(haystacks[i], needle,
                        0, haystacks[i].Length - 1);

                    Console.Write("In {");

                    foreach (int item in haystacks[i])
                        Console.Write(item + " ");

                    Console.Write("}}, {0} apare de {1} ori", needle, occurrences);

                    Console.WriteLine();
                }
        }
    }
}
