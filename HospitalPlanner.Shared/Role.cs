using System.Runtime.Serialization;

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
            switch (role)
            {
                case Role.Trainee:
                    return "Trainee";
                case Role.Nurse:
                    return "Nurse";
                case Role.GraduateNurse:
                    return "Graduate Nurse";
                case Role.PhysicianAssistant:
                    return "Physician Assistant";
                case Role.Physician:
                    return "Physician";
                case Role.SeniorPhysician:
                    return "Senior Physician";
                case Role.ChiefPhysician:
                    return "Chief Physician";
                default:
                    return string.Empty;
            }
        }
    }
}