using System;

namespace Domain
{
    public class Organiser
    {
        public IMeeting SetupMeeting(string attendee1, string attendee2, DateTime time)
        {
            var meeting = new TimedMeeting();
            meeting.AddAttendee(attendee1);
            meeting.AddAttendee(attendee2);
            meeting.Date = time;
            return meeting;
        }
    }

    internal class TimedMeeting : IMeeting
    {
        public DateTime Date;

        public void AddAttendee(string attendee1)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMeeting
    {
    }
}