using Hardware;

namespace Copy
{
    public class UserService
    {
        public void CopyUsers()
        {
            foreach (var userName in CsvFile.Read())
            {
                ActiveDirectory.CreateUser(userName);
            }
        }
    }
}