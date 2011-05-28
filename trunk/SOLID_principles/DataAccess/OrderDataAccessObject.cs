using System.Collections.Generic;
using BusinessObjects;

namespace DataAccess
{
    public class OrderDataAccessObject
    {

        public List<Order> FindOrdersForCustomer(int customerId)
        {
            var connection = new SuperDuperSqlConnection();
            connection.Open();
            var customers = new List<Order>();
            using (var transaction = connection.BeginTransaction())
            {
                var command = new SuperDuperSqlCommand(connection, "SELECT * FROM ORDERS WHERE CUSTID=" + customerId);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Order();
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