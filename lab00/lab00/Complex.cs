using System;
using System.IO;
using System.Collections.Generic;

namespace lab00
{
    class Complex
    {
        public float real;
        public float im;

        public static List<Complex> ReadData(string filename)
        {
            var result = new List<Complex>();

            try
            {
                var lines = File.ReadAllLines(filename);

                var n = int.Parse(lines[0]);

                for (int i = 1; i < n + 1; i++)
                {
                    var current = new Complex();

                    current.real = float.Parse(lines[i].Split(' ')[0]);
                    current.im = float.Parse(lines[i].Split(' ')[1]);

                    result.Add(current);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }

            return result;
        }

        public static void WriteContents(List<Complex> data)
        {
            foreach (Complex number in data)
                Console.WriteLine(number);
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", real, im);
        }
    }
}
