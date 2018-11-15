using System.Collections.Generic;

namespace HospitalPlanner.Shared
{
    public class Hospital
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public IReadOnlyCollection<Station> Stations { get; set; }
    }
}
