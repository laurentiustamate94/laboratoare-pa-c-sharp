using System;
using System.IO;

namespace p22
{
    class CountInversions
    {
        const int NO_TESTS = 2;

        int[][] data = new int[NO_TESTS][];

        private int Count(int[] vec)
        {
            // TODO Intoarceti numarul de inversiuni din vectorul vec

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
                    n = int.Parse(lines[i * 2]);

                    data[i] = new int[n];
                    for (j = 0; j < n; j++)
                        data[i][j] = int.Parse(lines[i * 2 + 1].Split(' ')[j]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }

        public void Test()
        {
            int inversions;

            for (int i = 0; i < NO_TESTS; i++)
            {
                inversions = Count(data[i]);

                Console.Write("In {");

                foreach (int item in data[i])
                    Console.Write(item + " ");

                Console.Write("}} sunt {0} inversiuni.", inversions);

                Console.WriteLine();
            }
        }
    }
}
