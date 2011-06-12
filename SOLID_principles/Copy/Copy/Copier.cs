using Hardware;

namespace Copy
{
    public class Copier
    {
        public void Copy()
        {
            foreach (var userName in CsvFile.Read())
            {
                ActiveDirectory.CreateUser(userName);
            }
        }
    }
}