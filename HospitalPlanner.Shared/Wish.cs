using System;

namespace HospitalPlanner.Shared
{
    public class Wish
    {
        public DateTime For { get; set; }

        public DateTime Until { get; set; }

        // Wish not to work when True; wish to Work in that time range when false
        public bool NotWorking { get; set; }

        public static Wish NewWish()
        {
            return new Wish {For = DateTime.MinValue, Until = DateTime.MinValue, NotWorking = true};
        }

        public (bool isConsidered, bool notWorking) IsConsideredFor(DateTime day)
        {
            return (day >= For && day <= Until, NotWorking);
        }
    }
}