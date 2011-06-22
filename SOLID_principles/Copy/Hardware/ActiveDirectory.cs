using System;
using System.Threading;

namespace Hardware
{
    public class ActiveDirectory
    {
        public void CreateNewUser(string username)
        {
            Console.WriteLine("Active Directory: creating user '{0}'", username);
            Thread.Sleep(250);
        }
    }
}