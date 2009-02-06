using System;

namespace Domain
{
    public class Organiser
    {
        public TodoItem SetupMeeting(string attendee)
        {
            return new TodoItem (attendee);
        }

        public UntimedMeeting SetupMeeting(string attendee1, string attendee2)
        {
            return new UntimedMeeting(attendee1, attendee2);
        }

        public TimedMeeting SetupMeeting(string attendee1, string attendee2, DateTime time)
        {
            return new TimedMeeting(attendee1, attendee2, time);
        }
    }

}