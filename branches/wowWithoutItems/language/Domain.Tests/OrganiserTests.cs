using System;
using Domain.Extensions;
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
        public void setup_todo_for_michel()
        {
            var todo = ToDo.For("Michel");
            Console.WriteLine(todo);
        }

        [Test]
        public void setup_untimed_meeting_between_qframe_and_michel()
        {
            var meeting = Meeting.Between("QFrame").And("Michel");
            Console.WriteLine(meeting);
        }

        [Test]
        public void setup_meeting_between_qframe_and_michel_at_8_tomorrow()
        {
            var meeting = 
                Meeting.Between("QFrame")
                       .And("Michel")
                       .At(20.Hours().Tomorrow());
            Console.WriteLine(meeting);
        }
    }
}