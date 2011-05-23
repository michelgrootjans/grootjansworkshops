namespace DependencyInversion
{
    public class Copy
    {
        public void Run()
        {
            int c;
            while ((c = Keyboard.Read()) != -1)
            {
                Printer.Write(c);
            }
        }
    }
}