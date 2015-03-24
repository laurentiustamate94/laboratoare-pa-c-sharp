using System;

namespace p3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lpss = new LongestPalindromeSubstring();

            lpss.ReadData("Resources/date.in");
            lpss.Test();
        }
    }
}
