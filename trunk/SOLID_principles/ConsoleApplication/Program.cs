using System;
using ServiceLayer;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var customerService = new CustomerService();
            var customers = customerService.GetAllCustomers();
            
            Console.WriteLine();
            Console.WriteLine("All your customers are:");
            foreach (var customer in customers)
            {
                Console.WriteLine("- " + customer.Name);
            }

            Console.Write("Hit ENTER to end...");
            Console.ReadLine();
        }
    }
}