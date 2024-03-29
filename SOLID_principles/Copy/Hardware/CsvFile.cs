﻿using System.Collections.Generic;

namespace Hardware
{
    public class CsvFile
    {
        private readonly string fileName;

        public CsvFile(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<string> ReadAllUsers()
        {
            CustomConsole.HighlightLine("Reading from '{0}'", fileName);

            yield return User("weytsko");
            yield return User("gladida");
            yield return User("grootmi");
        }

        private string User(string name)
        {
            CustomConsole.HighlightLine("CsvFile: reading user '{0}'", name);
            return name;
        }
    }
}