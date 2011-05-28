using System.Collections.Generic;
using System.Data;
using BusinessObjects;

namespace DataAccess
{
    public class CustomerDataAccessObject
    {
        private SuperDuperSqlConnection connection;

        public IDbTransaction BeginTransaction()
        {
            connection = new SuperDuperSqlConnection();
            connection.Open();
            return connection.BeginTransaction();
        }

        public List<Customer> FindAllCustomers()
        {
            var command = new SuperDuperSqlCommand(connection, "SELECT * FROM CUSTOMERS");
            var reader = command.ExecuteReader();
            var customers = new List<Customer>();
            while (!reader.Read())
            {
                var customer = new Customer {Id = reader.GetInt32(0), Name = reader.GetString(1)};
                customers.Add(customer);
            }
            return customers;
        }
    }
}