using System;
using System.Threading;

namespace Hardware
{
    public class TFS
    {
        public void AddUser(string userName)
        {
            if(userName == "grootmi")
            {
                Console.Write("TFS: I sense a resistance in this user");
                Wait(8);
                Console.WriteLine("refused.");
                Thread.Sleep(1000);
                return;
            }
            Console.Write("TFS: adding new user '{0}'", userName);
            Wait(8);
            Console.Write("almost there");
            Wait(8);
            Console.WriteLine("done.");
            Thread.Sleep(1000);
        }

        private void Wait(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
        }
    }
}