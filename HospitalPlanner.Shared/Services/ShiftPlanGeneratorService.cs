using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalPlanner.Shared.Services
{
    /// <summary>
    /// Bull-shit plan generator ... definitively still far away from something useful.
    /// 
    /// Notes:
    /// - when not enough of a certain Role is available, then that's it. Do not take more from other Staff. 
    ///   Less staff is on the shift at that time.
    /// - check DaysPerWeek and DaysPer Early/Late/Night and wishes
    /// - add 2 days (2.5d) of weekend after the night shift
    /// - and much more
    /// </summary>
    public class ShiftPlanGeneratorService
    {
        public IList<ShiftPlanEntry> Generate(DateTime from, DateTime until, IEnumerable<Staff> staff)
        {
            IList<ShiftPlanEntry> entries = new List<ShiftPlanEntry>();

            staff.ToList().ForEach(s =>
            {
                var t = from;

                t = AddShiftEntries(s, t, s.Preference.WorkingEarly, ShiftType.Early, entries);
                t = AddShiftEntries(s, t, s.Preference.WorkingLate, ShiftType.Late, entries);
                AddShiftEntries(s, t, s.Preference.WorkingNights, ShiftType.Night, entries);
            });

            return entries;
        }

        private static DateTime AddShiftEntries(Staff s, DateTime t, int working, ShiftType shiftType, IList<ShiftPlanEntry> entries)
        {
            for (int d = 0; d < working; d++)
            {
                if (IsValidWish(s, t))
                {
                    t = AddShiftEntry(entries, t, s, shiftType);
                }
            }

            return t;
        }

        private static DateTime AddShiftEntry(IList<ShiftPlanEntry> entries, DateTime t, Staff s, ShiftType shiftType)
        {
            entries.Add(new ShiftPlanEntry {Day = t, ShiftType = shiftType, Staff = s});
            t = t.AddDays(1);
            return t;
        }

        private static bool IsValidWish(Staff s, DateTime t)
        {
            return s.Preference.Wishes.Count == 0 || !s.Preference.Wishes.Any(w =>
            {
                (bool considered, bool notWorking) = w.IsConsideredFor(t);
                return considered && notWorking;
            });
        }
    }
}
