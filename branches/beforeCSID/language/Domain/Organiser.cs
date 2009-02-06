using System;

namespace Domain
{
    public class Organiser
    {
        public TodoItem SetupMeeting(string attendee)
        {
            return new TodoItem {Attendee = attendee};
        }

        public UntimedMeeting SetupMeeting(string attendee1, string attendee2)
        {
            return new UntimedMeeting { Attendee1 = attendee1,  Attendee2 = attendee2};
        }

        public TimedMeeting SetupMeeting(string attendee1, string attendee2, DateTime time)
        {
            return new TimedMeeting {Attendee1 = attendee1, Attendee2 = attendee2, Date = time};
        }
    }

}