using System;
using System.IO;

namespace p23
{
    class FindMissing
    {
        const int NO_TESTS = 2;

        int[][] data = new int[NO_TESTS][];

        private int Find(int[] vector)
        {
            int[] vec = (int[])vector.Clone();

            /* TODO Cautati binar elementul lipsa din vector
             * va trebui sa adaugati si o functie de partitionare, ca la quick sort
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
            int missing;

            for (int i = 0; i < NO_TESTS; i++)
            {
                missing = Find(data[i]);

                Console.Write("In {");

                foreach (int item in data[i])
                    Console.Write(item + " ");

                Console.Write("}} elementul lipsa este {0}.", missing);

                Console.WriteLine();
            }
        }
    }
}
