using System;

namespace p23
{
    class Program
    {
        static void Main(string[] args)
        {
            var findMissing = new FindMissing();

            findMissing.ReadData("Resources/date.in");
            findMissing.Test();
        }
    }
}
