using System;
using System.IO;

namespace p21
{
    class OrderStats
    {
        const int NO_TESTS = 2;

        int[][] data = new int[NO_TESTS][];

        private int KthMin(int[] v, int lower, int upper, int k)
        {
            /* TODO Completati codul pentru a afla al k-lea minim din vectorul v
             * trebuie sa adaugati si o functie de partitionare (ca la quick sort)
             */

            return 0;
        }

        private void QSort(int[] v, int lower, int upper)
        {
            /* TODO Completati codul pentru a realiza quicksort
             * folositi aceeasi functie de partitionare scrisa pentru kthMin
             */
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
            int kth;

            for (int i = 0; i < NO_TESTS; i++)
            {
                for (int k = 0; k < data[i].Length; k++)
                {
                    /* aflam al k-lea element, pentru toti k */
                    kth = KthMin(data[i], 0, data[i].Length - 1, k);

                    Console.Write("In {");

                    foreach (int item in data[i])
                        Console.Write(item + " ");

                    Console.Write("}}, al {0}-lea element ca ordine este {1}.", (k + 1), kth);

                    Console.WriteLine();
                }

                /* sortam vectorul folosind qsort definit mai jos */
                QSort(data[i], 0, data[i].Length - 1);

                Console.Write("Vectorul sortat este {{");

                foreach (int item in data[i])
                    Console.Write(item + " ");

                Console.Write("}}");

                Console.WriteLine();
            }
        }
    }
}
