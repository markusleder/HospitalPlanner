namespace HospitalPlanner.Shared
{
    public enum Role
    {
        None = 0,
        Trainee = 1,
        Nurse = 2,
        GraduateNurse = 3,
        PhysicianAssistant = 4,
        Physician = 5,
        SeniorPhysician = 6,
        ChiefPhysician = 7
    }

    public static class RoleExtensions
    {
        public static string ToRole(this Role role)
        {
            return role.ToString();
        }
    }
}