using System;

namespace p21
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderStats = new OrderStats();

            orderStats.ReadData("Resources/date.in");
            orderStats.Test();
        }
    }
}
