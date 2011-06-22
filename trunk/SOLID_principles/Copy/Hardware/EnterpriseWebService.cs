using System.Collections.Generic;

namespace Hardware
{
    public class EnterpriseWebService
    {
        public IEnumerable<string> GetAllUserNames()
        {
            CustomConsole.Highlight("WebService: returning all users...");
            var allUserNames = new List<string> {"danny", "jan", "koert", "johan", "gitte"};
            CustomConsole.HighlightLine("done.");
            return allUserNames;
        }
    }
}