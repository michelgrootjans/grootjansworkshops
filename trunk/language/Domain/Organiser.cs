using System;

namespace Domain
{
    public class Organiser
    {
        public ICalendarItem SetupMeeting(string attendee)
        {
            return new TodoItem {Attendee1 = attendee};
        }

        public ICalendarItem SetupMeeting(string attendee1, string attendee2)
        {
            return new UntimedMeeting { Attendee1 = attendee1,  Attendee2 = attendee2};
        }

        public ICalendarItem SetupMeeting(string attendee1, string attendee2, DateTime time)
        {
            return new TimedMeeting {Attendee1 = attendee1, Attendee2 = attendee2, Date = time};
        }
    }

    public interface ICalendarItem
    {
    }

    internal class TodoItem : ICalendarItem
    {
        public string Attendee1 { get; internal set; }

        public override string ToString()
        {
            return string.Format("Todo for {0}", Attendee1);
        }
    }

    internal class UntimedMeeting : TodoItem
    {
        public string Attendee2 { get; internal set; }

        public override string ToString()
        {
            return string.Format("Meeting between: {0}, {1}", Attendee1, Attendee2);
        }
    }

    internal class TimedMeeting : UntimedMeeting
    {
        public DateTime Date { get; internal set; }

        public override string ToString()
        {
            return string.Format("Meeting at {0} between: {1}, {2}", Date, Attendee1, Attendee2);
        }
    }
}