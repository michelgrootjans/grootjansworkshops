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
        public void setup_solo_meeting_for_michel()
        {
            var meeting = organiser.SetupMeeting("Michel");
            Console.WriteLine(meeting);
        }

        [Test]
        public void setup_untimed_meeting_between_qframe_and_michel()
        {
            var meeting = organiser.SetupMeeting("QFrame", "Michel");
            Console.WriteLine(meeting);
        }

        [Test]
        public void setup_meeting_between_qframe_and_michel_at_8_tomorrow()
        {
            var meeting = organiser.SetupMeeting("QFrame", "Michel", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 0, 0));
            Console.WriteLine(meeting);
        }


    }
}