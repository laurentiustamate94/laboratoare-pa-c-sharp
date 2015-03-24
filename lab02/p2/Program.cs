using System;

namespace p2
{
    class Program
    {
        static void Main(string[] args)
        {
            var giveChange = new GiveChange();

            giveChange.ReadData("Resources/date.in");
            giveChange.Test();
        }
    }
}
