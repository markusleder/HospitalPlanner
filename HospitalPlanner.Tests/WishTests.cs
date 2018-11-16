using System;
using FluentAssertions;
using HospitalPlanner.Shared;
using Xunit;

namespace HospitalPlanner.Tests
{
    public class WishTests
    {
        [Fact]
        public void GivenExpiredWish_ForDay_IsNotConsidered()
        {
            var target = new Wish { For = new DateTime(2018, 10, 20), Until = new DateTime(2018, 10, 20), NotWorking = true };

            var (isConsidered, notWorking) = target.IsConsideredFor(new DateTime(2018, 10, 1)); // earlier than wish range

            isConsidered.Should().BeFalse();
            notWorking.Should().BeTrue();
        }

        [Fact]
        public void GivenMatchingWish_ForDay_IsConsidered()
        {
            var target = new Wish { For = new DateTime(2018, 10, 20), Until = new DateTime(2018, 10, 20), NotWorking = true };

            var (isConsidered, notWorking) = target.IsConsideredFor(new DateTime(2018, 10, 20));

            isConsidered.Should().BeTrue();
            notWorking.Should().BeTrue();
        }

        [Fact]
        public void GivenMatchingWishRange_ForDay_IsConsidered()
        {
            var target = new Wish { For = new DateTime(2018, 10, 20), Until = new DateTime(2018, 10, 26), NotWorking = true };

            var (isConsidered, notWorking) = target.IsConsideredFor(new DateTime(2018, 10, 23));

            isConsidered.Should().BeTrue();
            notWorking.Should().BeTrue();
        }

        [Fact]
        public void GivenFutureNotWorkingWishRange_ForDay_IsNotConsidered()
        {
            var target = new Wish { For = new DateTime(2018, 10, 20), Until = new DateTime(2018, 10, 26), NotWorking = false };

            var (isConsidered, notWorking) = target.IsConsideredFor(new DateTime(2018, 11, 1)); // later than wish range

            isConsidered.Should().BeFalse();
            notWorking.Should().BeFalse();
        }

        [Fact]
        public void GivenNewDefaultWish_ForDay_IsNotConsidered()
        {
            var target = Wish.NewWish();

            var (isConsidered, notWorking) = target.IsConsideredFor(new DateTime(2018, 11, 1)); // later than wish range

            isConsidered.Should().BeFalse();
            notWorking.Should().BeTrue();
        }
    }
}
