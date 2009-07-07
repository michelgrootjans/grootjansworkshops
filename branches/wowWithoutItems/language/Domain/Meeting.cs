namespace Domain
{
    public class Meeting
    {
        public static TodoItem Between(string attendee)
        {
            return new TodoItem(attendee);
        }
    }
}