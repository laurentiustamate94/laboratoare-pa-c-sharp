using System;
using System.Collections.Generic;

namespace p2
{
    public enum BoatPosition
    {
        East,
        West
    }

    class State
    {
        #region Properties

        public int CannibalsWest { get; set; }
        public int CannibalsEast { get; set; }
        public int MissionariesWest { get; set; }
        public int MissionariesEast { get; set; }

        public BoatPosition Boat { get; set; }

        public int Distance { get; set; }
        public State Parent { get; set; }

        #endregion

        public State()
        {
            // NaN
        }

        public State(int[] distribution, BoatPosition boat, State parent, int distance)
        {

            MissionariesEast = distribution[0];
            CannibalsEast = distribution[1];

            MissionariesWest = distribution[2];
            CannibalsWest = distribution[3];

            Boat = boat;
            Distance = distance;
            Parent = parent;
        }

        public int ApproximateDistance()
        {
            /* 
             * TODO
             * 
             * Functie admisibila care sa estimeze 
             * costul pana la starea finala 
             */

            return 0;
        }

        public bool IsValidState()
        {

            if (MissionariesEast < 0 || CannibalsEast < 0)
                return false;

            if (MissionariesWest < 0 || CannibalsWest < 0)
                return false;

            if (MissionariesEast > 0 && MissionariesEast < CannibalsEast)
                return false;

            if (MissionariesWest > 0 && MissionariesWest < CannibalsWest)
                return false;

            return true;
        }

        public List<State> ExpandCurrentState()
        {
            State state;
            var neighbours = new List<State>();

            state = MoveOneCannibalOneMissionary();
            if (state != null)
                neighbours.Add(state);

            state = MoveTwoCannibals();
            if (state != null)
                neighbours.Add(state);

            state = MoveTwoMissionaries();
            if (state != null)
                neighbours.Add(state);

            state = MoveOneCannibal();
            if (state != null)
                neighbours.Add(state);

            state = MoveOneMisionary();
            if (state != null)
                neighbours.Add(state);

            return neighbours;
        }

        #region Black magic right here

        private State CreateState(int[] distribution, BoatPosition boat)
        {
            var east = new int[]
            {
                MissionariesEast + distribution[0],
                CannibalsEast + distribution[1]
            };

            var west = new int[]
            {
                MissionariesWest + distribution[2],
                CannibalsWest + distribution[3]
            };

            var newState = new State(new int[] { east[0], east[1], west[0], west[1] }, boat, this, Distance + 1);

            if (!newState.IsValidState())
                return null;

            return newState;
        }

        private State MoveOneMisionary()
        {
            State state;

            if (Boat == BoatPosition.East)
                state = CreateState(new int[] { -1, 0, 1, 0 }, BoatPosition.West);
            else
                state = CreateState(new int[] { 1, 0, -1, 0 }, BoatPosition.East);

            return state;
        }

        private State MoveOneCannibal()
        {
            State state;

            if (Boat == BoatPosition.East)
                state = CreateState(new int[] { 0, -1, 0, 1 }, BoatPosition.West);
            else
                state = CreateState(new int[] { 0, 1, 0, -1 }, BoatPosition.East);

            return state;
        }

        private State MoveTwoMissionaries()
        {
            State state;

            if (Boat == BoatPosition.East)
                state = CreateState(new int[] { -2, 0, 2, 0 }, BoatPosition.West);
            else
                state = CreateState(new int[] { 2, 0, -2, 0 }, BoatPosition.East);

            return state;
        }

        private State MoveTwoCannibals()
        {
            State state;

            if (Boat == BoatPosition.East)
                state = CreateState(new int[] { 0, -2, 0, 2 }, BoatPosition.West);
            else
                state = CreateState(new int[] { 0, 2, 0, -2 }, BoatPosition.East);

            return state;
        }

        private State MoveOneCannibalOneMissionary()
        {
            State state;

            if (Boat == BoatPosition.East)
                state = CreateState(new int[] { -1, -1, 1, 1 }, BoatPosition.West);
            else
                state = CreateState(new int[] { 1, 1, -1, -1 }, BoatPosition.East);

            return state;
        }

        #endregion

        private void PrintReversePath(State current)
        {
            if (current == null)
                return;

            PrintReversePath(current.Parent);

            Console.WriteLine(current);
        }

        public void PrintPath()
        {
            PrintReversePath(this);
        }

        public override int GetHashCode()
        {
            var firstHash = CannibalsEast.GetHashCode() + MissionariesEast.GetHashCode();
            var secondHash = CannibalsWest.GetHashCode() + MissionariesWest.GetHashCode();

            return (firstHash + secondHash) * secondHash + firstHash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as State;

            if (CannibalsWest != other.CannibalsWest)
                return false;

            if (CannibalsEast != other.CannibalsEast)
                return false;

            if (MissionariesWest != other.MissionariesWest)
                return false;

            if (MissionariesEast != other.MissionariesEast)
                return false;

            if (Boat != other.Boat)
                return false;

            return true;
        }

        public override string ToString()
        {
            return String.Format("( M = {0}, C = {1} | M = {2}, C = {3} )",
                MissionariesEast, CannibalsEast, MissionariesWest, CannibalsWest);
        }
    }
}
