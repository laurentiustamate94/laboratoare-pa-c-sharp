using System;
using System.Collections.Generic;
using System.IO;

namespace p2
{
    class Program
    {
        static List<Cell> cells;
        static Stack<Cell> cellStack = new Stack<Cell>();

        static void Main(string[] args)
        {
            ReadData("Resources/date.in");

            //TODO Afisati parcurgerea celulelor.
        }

        public static void DFS(Cell cell)
        {
            /**
             * TODO 
             * 
             * Implementati DFS. 
             * La finalul parcurgerii unei celule, adaugati celula in cellStack.
             */
        }

        public static void ReadData(string filename)
        {
            Dictionary<string, Cell> data = new Dictionary<string, Cell>();

            try
            {
                var lines = File.ReadAllLines(filename);

                for (int i = 0; i < 6; i++)
                {
                    string[] tokens = lines[i].Split(' ');

                    Cell cell = null;

                    if (!data.ContainsKey(tokens[0]))
                    {
                        cell = new Cell(tokens[0]);
                        data.Add(tokens[0], cell);
                    }
                    else
                        cell = data[tokens[0]];

                    for (int j = 1; j < tokens.Length; j++)
                        if (tokens[j].Length == 2)
                        {
                            if (!data.ContainsKey(tokens[j]))
                                data.Add(tokens[j], new Cell(tokens[j]));

                            data[tokens[j]].DependentCells.Add(cell);
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }

            cells = new List<Cell>(data.Values);
        }
    }
}
