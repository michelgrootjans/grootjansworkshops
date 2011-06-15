using System.Collections.Generic;
using System.Threading;

namespace Hardware
{
    public static class EnterpriseWebService
    {
        public static IEnumerable<string> GetAllUserNames()
        {
            CustomConsole.Highlight("WebService: returning all users...");
            Thread.Sleep(2000);
            var allUserNames = new List<string>{"danny", "jan", "koert", "johan", "gitte"};
            CustomConsole.HighlightLine("done.");
            return allUserNames;
        }

        private static string User(string userName)
        {
            return userName;
        }
    }
}