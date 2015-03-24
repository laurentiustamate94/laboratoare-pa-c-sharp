using System;
using System.Linq;
using System.Collections.Generic;

namespace lab00
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Citire date din fisier */
            var numbers = Complex.ReadData("Resources/date.in");
            Console.WriteLine("Vectorul initial:");
            Complex.WriteContents(numbers);

            /* Verifica sortarea. */
            var sorted = GetSorted(numbers);
            Console.WriteLine("Vectorul sortat:");
            Complex.WriteContents(sorted);

            /* Verifica maparea. */
            var mapping = GetMapping(numbers);
            Console.WriteLine("Maparea:");

            foreach (var element in sorted)
                Console.WriteLine("{0} e pe pozitia {1}",
                    element, mapping.FirstOrDefault(x => x.Key.Equals(element)).Value);
        }

        static List<Complex> GetSorted(List<Complex> numbers)
        {
            var result = new List<Complex>();

            /* TODO 
             * Folosind SortedSet, adaugati elementele din numbers in ordine crescatoare.
             * Pentru SortedSet folositi comparatorul definit mai jos 
             */

            return result;
        }

        static Dictionary<Complex, int> GetMapping(List<Complex> numbers)
        {
            var result = new Dictionary<Complex, int>();

            /* TODO 
             * Adaugati in map, pentru fiecare element din numbers, 
             * pozitia sa in vectorul sortat.
             */

            return result;
        }
    }

    class ComplexComparator : Comparer<Complex>
    {
        public override int Compare(Complex x, Complex y)
        {
            // TODO Intoarceti un numar pozitiv daca a > b, negativ altfel

            throw new NotImplementedException();
        }
    }
}
