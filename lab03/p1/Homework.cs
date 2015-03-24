using System;

namespace p1
{
    class Homework
    {
        public int Deadline { get; private set; }
        public int Points { get; private set; }

        public Homework(int deadline, int points)
        {
            Deadline = deadline;
            Points = points;
        }

        public override string ToString()
        {
            return String.Format("(d:{0}, p:{1}) ", Deadline, Points);
        }
    }
}
