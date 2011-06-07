using System;
using Hardware;

namespace Copy
{
    public class Copier
    {
        public void Copy()
        {
            string c;
            while ((c = Keyboard.Read()) != Environment.NewLine)
            {
                Printer.Write(c);
            }
        }
    }
}
