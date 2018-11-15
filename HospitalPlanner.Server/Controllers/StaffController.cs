using HospitalPlanner.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalPlanner.Server.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Staff> GetAllStaff()
        {
            var rng = new Random();
            return Enumerable.Range(1, Station.NumberOfStaff).Select(index => new Staff
            {
                Name = Names.SomeNames[rng.Next(Names.SomeNames.Length)],
                DaysPerWeek = rng.Next(3, 5),
                Role = (Role)rng.Next((int)Role.Trainee, (int)Role.ChiefPhysician),
                Preference = Preferences.Default
            });
        }
    }
}
