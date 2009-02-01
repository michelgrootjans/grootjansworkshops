using System;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class OrganiserTests
    {
        private Organiser organiser;

        [SetUp]
        public void SetUp()
        {
            organiser = new Organiser();
        }

        [Test]
        public void setup_meeting_between_albert_and_john_at_8_tomorrow()
        {
            var meeting = organiser.SetupMeeting("QFrame", "Michel", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 0, 0));
            Console.WriteLine(meeting);
        }


    }
}