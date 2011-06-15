using System;
using System.Threading;

namespace Hardware
{
    public static class ActiveDirectory
    {
        public static void CreateUser(string username)
        {
            Thread.Sleep(250);
            Console.WriteLine("Active Directory: creating user '{0}'", username);
        }
    }
}