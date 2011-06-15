using System.Collections.Generic;
using System.Threading;

namespace Hardware
{
    public static class CsvFile
    {
        public static IEnumerable<string> Read()
        {
            yield return User("grootmi");
            yield return User("gladida");
            yield return User("heyleba");
        }

        private static string User(string name)
        {
            Thread.Sleep(250);
            CustomConsole.Highlight("CsvFile: reading user '{0}'", name);
            return name;
        }
    }
}