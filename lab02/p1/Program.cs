using System;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            var plan = new Plan();

            plan.ReadData("Resources/date.in");
            plan.Test();
        }
    }
}
