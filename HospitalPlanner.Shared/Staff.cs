namespace HospitalPlanner.Shared
{
    public class Staff
    {
        public string Name { get; set; }

        public int DaysPerWeek { get; set; }

        public Role Role { get; set; }

        public Preferences Preference { get; set; }

        public Staff()
        {
            Role = new Role();
            //Preference = Preferences.Default;
        }
    }
}
