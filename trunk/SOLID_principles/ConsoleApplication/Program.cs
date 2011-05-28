using System;
using System.Collections.Generic;
using BusinessObjects;
using ServiceLayer;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var customerService = new CustomerService();
            var customers = customerService.GetAllCustomers();
            
            Print(customers);
        }

        private static void Print(List<Customer> customers)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("All your customers are:");
            Console.WriteLine("***********************");
            foreach (var customer in customers)
            {
                Console.WriteLine("- " + customer.Name);
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t" + order.Name);
                }
            }

            Console.Write("Hit ENTER to end...");
            Console.ReadLine();
        }
    }
}