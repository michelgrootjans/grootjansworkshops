using System.Collections.Generic;
using BusinessObjects;

namespace DataAccess
{
    public class CustomerDataAccessObject
    {
        public List<Customer> FindAllCustomers()
        {
            var connection = new SuperDuperSqlConnection();
            var command = new SuperDuperSqlCommand("SELECT * FROM CUSTOMERS");
            command.Connection = connection;

            connection.Open();
            var customers = new List<Customer>();
            using (var transaction = connection.BeginTransaction())
            {
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