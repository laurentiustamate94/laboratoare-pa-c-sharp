using System;
using System.IO;

namespace p1
{
    class HomeworkPlanner
    {
        const int NO_TESTS = 3;

        int[] lastDay = new int[NO_TESTS];
        Homework[][] homeworks = new Homework[NO_TESTS][];

        Homework[] ChooseHomeworks(Homework[] homeworks, int lastDay)
        {
            /* TODO Adaugati in planning pe indicele i, tema care se va rezolva
             * in ziua i. Daca nu se va rezolva nicio tema, lasati null
             */

            Homework[] planning = new Homework[lastDay + 1];
            Homework[] homeworksCopy = new Homework[homeworks.Length];


            int i = 0;
            foreach (var h in homeworks)
                homeworksCopy[i++] = new Homework(h.Deadline, h.Points);

            /* TODO porniti planificarea de la ultima zi si adaugati tema care
             * maximizeaza numarul total de puncte obtinute.
             */

            return planning;
        }

        public void ReadData(string filename)
        {
            try
            {
                int homeworksCount, i, j;
                int deadline, points;

                var lines = File.ReadAllLines(filename);

                for (i = 0; i < NO_TESTS; i++)
                {
                    lastDay[i] = int.Parse(lines[i * 7]);

                    homeworksCount = int.Parse(lines[i * 7 + 1]);

                    homeworks[i] = new Homework[homeworksCount];
                    for (j = 0; j < homeworksCount; j++)
                    {
                        deadline = int.Parse(lines[i * 7 + j + 2].Split(' ')[0]);
                        points = int.Parse(lines[i * 7 + j + 2].Split(' ')[1]);

                        homeworks[i][j] = new Homework(deadline, points);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }
        }

        public void Test()
        {
            int j;

            for (int i = 0; i < NO_TESTS; i++)
            {
                Console.Write("Pentru temele ");
                Console.WriteLine(GetOutput(homeworks[i]));

                Homework[] solution = ChooseHomeworks(homeworks[i], lastDay[i]);

                j = 0;
                foreach (var h in solution)
                    Console.WriteLine("Ziua {0}: {1}", j++, h);

                Console.WriteLine();
            }
        }

        private string GetOutput(Homework[] v)
        {
            string output = "{ ";

            foreach (var item in v)
                output += item + " ";

            return output + "}";
        }
    }
}
