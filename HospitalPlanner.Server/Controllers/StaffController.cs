using HospitalPlanner.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace HospitalPlanner.Server.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private IMemoryCache _cache;
        private IEnumerable<Staff> Staff;

        public StaffController(IMemoryCache cache)
        {
            _cache = cache;

            var rng = new Random();

            if (!_cache.TryGetValue(CacheKeys.Entry, out Staff))
            {
                Staff = GenerateAllStaff(rng).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(CacheKeys.Entry, Staff, cacheEntryOptions);
            }
        }

        private static IEnumerable<Staff> GenerateAllStaff(Random rng)
        {
            return Enumerable
                .Range(1, Station.NumberOfStaff)
                .Select(index => GenerateOneStaff(index, rng));
        }

        [HttpGet("[action]")]
        public IEnumerable<Staff> GetAllStaff()
        {
            return Staff;
        }

        private static Staff GenerateOneStaff(int index, Random rng)
        {
            var d = rng.Next(3, 6);

            return new Staff
            {
                // do duplicates, taking females from end upw.
                Name = Names.SomeNames[Names.SomeNames.Length - 1 - index],     
                DaysPerWeek = d,
                Role = (Role)rng.Next((int)Role.Trainee, (int)Role.ChiefPhysician),
                Preference = SetSomeReasonablePreference(d)
            };
        }

        private static Preferences SetSomeReasonablePreference(int daysPerWeek)
        {
            var p = new Preferences {WorkingEarly = 1, WorkingLate = 1, WorkingNights = 1};

            switch (daysPerWeek)
            {
                case 5:
                    p.WorkingEarly++;
                    p.WorkingLate++;
                    break;
                case 4:
                    p.WorkingLate++;
                    break;
            }

            if (p.WorkingEarly + p.WorkingLate + p.WorkingNights != daysPerWeek)
            {
                throw new InvalidOperationException("inconsistent week working days.");
            }

            return p;
        }
    }
}
