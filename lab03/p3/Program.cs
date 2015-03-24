using System;

namespace p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Input[] inputs = 
            {
                new Input(3, 2), // 6
                new Input(123, 4), // 2490
                new Input(2014, 3) // 244
            };

            foreach (var input in inputs)
            {
                var bill = new Bill(input.N, input.R);

                Console.WriteLine("N = {0}, R = {1} -> {2} {3}",
                    input.N, input.R, bill.CountSolutions(), bill.CountSolutionsLog());
            }
        }
    }
}
