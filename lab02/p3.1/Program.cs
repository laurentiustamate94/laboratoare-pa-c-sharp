using System;

namespace p3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lcss = new LongestCommonSubsequence();

            lcss.ReadData("Resources/date.in");
            lcss.Test();
        }
    }
}
