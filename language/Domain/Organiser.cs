using System;

namespace Domain
{
    public class Organiser
    {
        public IMeeting SetupMeeting(string attendee1, string attendee2, DateTime time)
        {
            var meeting = new TimedMeeting {Attendee1 = attendee1, Attendee2 = attendee2, Date = time};

            return meeting;
        }
    }

    internal class TimedMeeting : IMeeting
    {
        public DateTime Date { get; internal set; }
        public string Attendee1 { get; internal set; }
        public string Attendee2 { get; internal set; }

        public override string ToString()
        {
            return string.Format("Meeting at {0} between: {1}, {2}", Date, Attendee1, Attendee2);
        }
    }

    public interface IMeeting
    {
    }
}