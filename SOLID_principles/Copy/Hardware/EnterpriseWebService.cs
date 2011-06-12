using System.Collections.Generic;

namespace Hardware
{
    public static class EnterpriseWebService
    {
        public static IEnumerable<string> GetAllUserNames()
        {
            yield return User("Michel Grootjans");
        }

        private static string User(string userName)
        {
            CustomConsole.Highlight("WebService: returning {0}", userName);
            return userName;
        }
    }
}