using System;

namespace Domain
{
    public interface ICalendarItem
    {
    }

    public class TodoItem : ICalendarItem
    {
        public string Attendee { get; internal set; }

        public override string ToString()
        {
            return string.Format("Todo for {0}", Attendee);
        }
    }

    public class UntimedMeeting : ICalendarItem
    {
        public string Attendee1 { get; internal set; }
        public string Attendee2 { get; internal set; }

        public override string ToString()
        {
            return string.Format("Meeting between: {0}, {1}", Attendee1, Attendee2);
        }
    }

    public class TimedMeeting : ICalendarItem
    {
        public string Attendee1 { get; internal set; }
        public string Attendee2 { get; internal set; }
        public DateTime Date { get; internal set; }

        public override string ToString()
        {
            return string.Format("Meeting at {0} between: {1}, {2}", Date, Attendee1, Attendee2);
        }
    }
}