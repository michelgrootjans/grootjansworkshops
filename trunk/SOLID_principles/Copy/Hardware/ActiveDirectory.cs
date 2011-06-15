using System;
using System.Threading;

namespace Hardware
{
    public static class ActiveDirectory
    {
        public static void CreateUser(string username)
        {
            Console.WriteLine("Active Directory: creating user '{0}'", username);
            Thread.Sleep(250);
        }
    }
}