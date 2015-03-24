using System;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            var planner = new HomeworkPlanner();

            planner.ReadData("Resources/date.in");
            planner.Test();
        }
    }
}
