﻿using Copy;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var copier = new UserService();
            copier.CopyUsers();
        }
    }
}
