using System;
using System.Collections.Generic;
using System.IO;

namespace p1
{
    class Plan
    {
        const int NO_TESTS = 2;

        int[][] distances = new int[NO_TESTS][];
        int[] m = new int[NO_TESTS];

        private List<int> PlanRoute(int m, int[] distances)
        {
            List<int> result = new List<int>();

            // TODO
            // Calculati numarul minim de opriri la benzinarii si returnati
            // o lista cu indicii benzinariilor la care se vor face opririle

            return result;
        }

        public void ReadData(string filename)
        {
            try
            {
                int n, i, j;

                var lines = File.ReadAllLines(filename);

                for (i = 0; i < NO_TESTS; i++)
                {
                    /* read the maximum number of km */
                    m[i] = int.Parse(lines[i * 3]);

                    /* read the distances array */
                    n = int.Parse(lines[i * 3 + 1]);

                    distances[i] = new int[n];
                    for (j = 0; j < n; j++)
                        distances[i][j] = int.Parse(lines[i * 3 + 2].Split(' ')[j]);
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
                List<int> stops = PlanRoute(m[i], distances[i]);

                Console.Write("Pentru ruta {{");

                foreach (var item in distances[i])
                    Console.Write(item + " ");

                Console.Write("}}, opririle planificate sunt {{");

                if (stops != null)
                    foreach (var item in stops)
                        Console.Write(item + " ");

                Console.WriteLine("}} si numarul minim de opriri este {0}",
                    stops != null ? stops.Count : 0);
            }
        }
    }
}
