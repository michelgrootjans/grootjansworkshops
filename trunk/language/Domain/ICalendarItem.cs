using System;

namespace Domain
{
    public interface ICalendarItem
    {
    }

    public class TodoItem : ICalendarItem
    {
        public TodoItem(string attendee)
        {
            Attendee = attendee;
        }

        public string Attendee { get; private set; }

        public override string ToString()
        {
            return string.Format("Todo for {0}", Attendee);
        }

        public UntimedMeeting And(string attendee2)
        {
            return new UntimedMeeting(Attendee, attendee2);
        }
    }

    public class UntimedMeeting : ICalendarItem
    {
        public string Attendee1 { get; private set; }
        public string Attendee2 { get; private set; }

        public UntimedMeeting(string attendee1, string attendee2)
        {
            Attendee1 = attendee1;
            Attendee2 = attendee2;
        }

        public override string ToString()
        {
            return string.Format("Meeting between: {0}, {1}", Attendee1, Attendee2);
        }

        public TimedMeeting At(DateTime appointment)
        {
            return new TimedMeeting(Attendee1, Attendee2, appointment);
        }
    }

    public class TimedMeeting : ICalendarItem
    {
        public string Attendee1 { get; private set; }
        public string Attendee2 { get; private set; }
        public DateTime Date { get; private set; }

        public TimedMeeting(string attendee1, string attendee2, DateTime date)
        {
            Attendee1 = attendee1;
            Attendee2 = attendee2;
            Date = date;
        }

        public override string ToString()
        {
            return string.Format("Meeting at {0} between: {1}, {2}", Date, Attendee1, Attendee2);
        }
    }
}