namespace HospitalPlanner.Shared
{
    public class Preferences        
    {
        public int WorkingNights { get; set; }

        public int WorkingEarly { get; set; }

        public int WorkingLate { get; set; }

        public static Preferences Default => new Preferences {WorkingEarly = 2, WorkingLate = 2, WorkingNights = 1};
    }
}