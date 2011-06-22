using Hardware;

namespace Copy
{
    public class UserService
    {
        public void CopyUsers()
        {
            var csvFile = new CsvFile("users.csv");
            foreach (var userName in csvFile.ReadAllUsers())
            {
                var activeDirectory = new ActiveDirectory();
                activeDirectory.CreateNewUser(userName);
            }
        }
    }
}