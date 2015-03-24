using System;

namespace p13
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessMe guess = new GuessMe();

            guess.SetUnknown(1);
            if (guess.Guess() == 1)
                Console.WriteLine("Corect!");
            else
                Console.WriteLine("Gresit :(");

            guess.SetUnknown(10);
            if (guess.Guess() == 10)
                Console.WriteLine("Corect!");
            else
                Console.WriteLine("Gresit :(");

            guess.SetUnknown(15);
            if (guess.Guess() == 15)
                Console.WriteLine("Corect!");
            else
                Console.WriteLine("Gresit :(");

            guess.SetUnknown(42);
            if (guess.Guess() == 42)
                Console.WriteLine("Corect!");
            else
                Console.WriteLine("Gresit :(");
        }
    }
}
