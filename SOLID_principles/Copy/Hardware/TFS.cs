using System;
using System.Threading;

namespace Hardware
{
    public static class TFS
    {
        public static void AddUser(string userName)
        {
            Console.Write("TFS: adding new user '{0}'", userName);
            Wait(8);
            Console.Write("almost there");
            Wait(8);
            Console.WriteLine("done.");
            Thread.Sleep(1000);
        }

        private static void Wait(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
        }
    }
}