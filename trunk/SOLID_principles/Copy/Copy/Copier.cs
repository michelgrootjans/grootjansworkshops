using Hardware;

namespace Copy
{
    public class Copier
    {
        public void Copy()
        {
            while (true)
            {
                var text = Keyboard.Read();
                Printer.Print(text);
            }
        }
    }
}