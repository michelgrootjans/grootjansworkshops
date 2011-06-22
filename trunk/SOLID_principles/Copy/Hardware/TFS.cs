namespace Hardware
{
    public class TFS
    {
        public void AddUser(string userName)
        {
            if (userName == "grootmi")
            {
                CustomConsole.Write("TFS: I sense a resistance in this user");
                CustomConsole.WriteLine("refused.");
                return;
            }
            CustomConsole.Write("TFS: adding new user '{0}'", userName);
            CustomConsole.Write("almost there");
            CustomConsole.WriteLine("done.");
        }
    }
}