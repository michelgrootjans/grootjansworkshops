using System;
using System.Threading;

namespace Hardware
{
    public static class TFS
    {
        public static void AddUser(string userName)
        {
            Console.Write("TFS: adding new user '{0}'", userName);
            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(250);
                Console.Write(".");
            }
            Console.WriteLine("done.");
            Thread.Sleep(1000);
        }
    }
}