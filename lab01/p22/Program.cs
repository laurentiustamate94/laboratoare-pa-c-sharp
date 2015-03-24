using System;

namespace p22
{
    class Program
    {
        static void Main(string[] args)
        {
            var countInversions = new CountInversions();

            countInversions.ReadData("Resources/date.in");
            countInversions.Test();
        }
    }
}
