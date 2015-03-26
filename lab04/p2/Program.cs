using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace p2
{
    class Program
    {
        static int bktCounter = 0;
        static int solutionCounter = 0;

        /// <summary>
        /// Implementarea functiei de Verifica(Xk, Xm) - actualizeaza domeniul lui c1
        /// si pastreaza valorile care au un corespondent in c2 care sa satisfaca
        /// restrictiile - intoarce true daca domeniul variabilei c1 a suferit
        /// modificari
        /// </summary>
        public static bool Check(Cell c1, Cell c2)
        {
            var delete = false;

            // TODO 1: Pentru fiecare valoare din domeniul variabilei c1
            // verifica daca exista o valoare valida in domeniul lui c2

            return delete; // intoarcem true daca s-au sters valori
        }

        /// <summary>
        /// Metoda care aplica agloritmul AC3 pe variabilele primite in lista cells
        /// Intoarce true daca un domeniu al vreunei variabile a devenit gol
        /// </summary>
        public static bool DoAC3(List<Cell> cells)
        {
            var queue = new Queue<Arc>();

            // TODO 2: Initializare coada cu multimea arcelor

            // TODO 3: Cat timp mai exista arce de verificat in coada,
            // extrage primul arc si verifica domeniile folosind functia check de mai sus

            return false;
        }

        /// <summary>
        /// Implementarea backtracking + AC-3 simplu
        /// </summary>
        public static void DoBKT(List<Cell> cells, int row, int column)
        {
            bktCounter++; // incrementam numarul total de intrari in recursivitate
            //TODO 4: Testam daca am completat tot si afisam solutia

            // Aplicam algoritmul AC3 pe variabilele din lista de celule
            if (DoAC3(cells))
                return;

            /* TODO 5: Aplicam backtracking pe valorile ramase in domeniul variabilei curente.
             * Atentie! va trebui sa folosim o copie a listei cells la intrarea in recursivitate.
             * Daca setam direct valoarea pe lista originala cells, la intoarcerea din
             * recursivitate vom pierde celelalte valori din domeniul variabilei pe care iteram.
             * Hint: folositi functia GetCopy
             */
        }

        public static List<Cell> GetCopy(List<Cell> cells)
        {
            var cellsCopy = new List<Cell>();

            foreach (var item in cells)
                cellsCopy.Add(item.Clone());

            return cellsCopy;
        }

        public static bool AreValid(Cell c1, Cell c2)
        {
            return !AreRelated(c1, c2) || c1.Value != c2.Value;
        }

        public static bool AreRelated(Cell c1, Cell c2)
        {
            if (c1.Row == c2.Row)
                return true;

            if (c1.Column == c2.Column)
                return true;

            if (c1.Row / 3 == c2.Row / 3 && c1.Column / 3 == c2.Column / 3)
                return true;

            return false;
        }

        public static void PrintGrid(List<Cell> cells)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var cellValue = cells.ElementAt(i * 9 + j).Value;
                    var message = cellValue == 0 ? " " : cellValue.ToString();

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

                var cells = new List<Cell>(81);

                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        var value = int.Parse(lines[i].Split(' ')[j]);

                        if (value == 0)
                            cells.Add(new Cell(i, j));
                        else
                            cells.Add(new Cell(i, j, value));
                    }

                bktCounter = 0;
                solutionCounter = 0;

                DoBKT(cells, 0, 0);

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
