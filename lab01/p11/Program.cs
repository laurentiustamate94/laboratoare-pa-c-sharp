using System;

namespace p11
{
    class Program
    {
        static void Main(string[] args)
        {
            var occurrences = new Occurrences();

            occurrences.ReadData("Resources/date.in");
            occurrences.Test();
        }
    }
}
