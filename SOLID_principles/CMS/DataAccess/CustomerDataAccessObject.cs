﻿using System.Collections.Generic;
using BusinessObjects;
using DataAccess.Utilities;

namespace DataAccess
{
    public class CustomerDataAccessObject
    {
        public List<Customer> FindAllCustomers()
        {
            var connection = new SqlConnection();
            connection.Open();

            var customers = new List<Customer>();
            using (var transaction = connection.BeginTransaction())
            {
                var command = new SqlCommand("SELECT * FROM CUSTOMERS");
                command.Connection = connection;
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.Id = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);
                    customers.Add(customer);
                }
                transaction.Commit();
            }
            return customers;
        }
    }
}