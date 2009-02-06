namespace Domain
{
    public class ToDo
    {
        public static TodoItem For(string attendee)
        {
            return new TodoItem(attendee);
        }
    }
}