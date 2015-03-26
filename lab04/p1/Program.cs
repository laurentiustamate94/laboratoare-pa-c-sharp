using System;
using System.IO;

namespace p1
{
    class Program
    {
        static int bktCounter = 0;
        static int solutionCounter = 0;

        /// <summary>
        /// Implementarea backtracking-ului simplu
        /// </summary>
        public static void DoBKT(int[,] grid, int row, int column)
        {
            bktCounter++; // incrementam numarul total de intrari in recursivitate

            // TODO 2: Implementarea algoritmului de backtracking simplu
            // TODO 3: Afisarea tuturor solutiilor gasite
            // TODO 4: Incrementarea variabilei solutionCounter pentru fiecare solutie
        }

        /// <summary>
        /// Intoarce true daca cifra adaugata la pozitia (row, column)
        /// nu contrazice cifrele deja completate
        /// </summary>
        public static bool IsValid(int[,] grid, int row, int column)
        {
            for (int i = 0; i < 9; i++)
                if (i != column && grid[row, i] != 0 && grid[row, i] == grid[row, column])
                    return false;

            for (int i = 0; i < 9; i++)
                if (i != row && grid[i, column] != 0 && grid[i, column] == grid[row, column])
                    return false;

            for (int i = (row / 3) * 3; i < (row / 3 + 1) * 3; i++)
                for (int j = (column / 3) * 3; j < (column / 3 + 1) * 3; j++)
                    if ((i != row || j != column) &&
                            grid[i, j] != 0 && grid[i, j] == grid[row, column])
                        return false;

            return true;
        }

        public static void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var message = grid[i, j] == 0 ? " " : grid[i, j].ToString();

                    Console.Write("{0} ", message);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try
            {
                var lines = File.ReadAllLines("Resources/sudoku.in");

                var grid = new int[9, 9];

                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        grid[i, j] = int.Parse(lines[i].Split(' ')[j]);

                bktCounter = 0;
                solutionCounter = 0;

                DoBKT(grid, 0, 0);

                Console.WriteLine("Numar de intrari in recursivitare : {0}", bktCounter);
                Console.WriteLine("Numar de solutii gasite: {0}", solutionCounter);
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }
    }
}
