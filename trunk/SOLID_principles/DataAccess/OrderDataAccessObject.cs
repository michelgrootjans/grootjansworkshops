using System.Collections.Generic;
using BusinessObjects;

namespace DataAccess
{
    public class OrderDataAccessObject
    {
        private readonly SuperDuperSqlConnection connection;

        public OrderDataAccessObject(SuperDuperSqlConnection connection)
        {
            this.connection = connection;
        }

        public List<Order> FindOrdersForCustomer(int customerId)
        {
            var command = new SuperDuperSqlCommand(connection, "SELECT * FROM ORDERS WHERE CUSTID=" + customerId);
            var reader = command.ExecuteReader();
            var customers = new List<Order>();
            while (!reader.Read())
            {
                var customer = new Order {Id = reader.GetInt32(0), Name = reader.GetString(1)};
                customers.Add(customer);
            }
            return customers;
        }
    }
}