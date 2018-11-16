using System;

namespace HospitalPlanner.Shared
{
    public class ShiftPlanEntry
    {
        public DateTime Day { get; set; }

        public ShiftType ShiftType { get; set; }

        public Staff Staff { get; set; }
    }
}