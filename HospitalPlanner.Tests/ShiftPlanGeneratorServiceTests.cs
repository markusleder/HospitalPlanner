using System;
using System.Collections.Generic;
using FluentAssertions;
using HospitalPlanner.Shared;
using HospitalPlanner.Shared.Services;
using Xunit;

namespace HospitalPlanner.Tests
{
    public class ShiftPlanGeneratorServiceTests
    {
        [Fact]
        public void GivenMatchingStaff_Generate_HasAddedEntries()
        {
            var service = new ShiftPlanGeneratorService();
            var staff = new List<Staff> { CreateStaff() };

            var entries = service.Generate(new DateTime(2018, 10, 20), new DateTime(2018, 10, 27), staff);

            entries.Should().NotBeEmpty();
            entries.Should().HaveCount(5);
        }

        private static Staff CreateStaff()
        {
            return new Staff { DaysPerWeek = 5, Name = Guid.NewGuid().ToString(), Role = Role.Nurse};
        }
    }
}
