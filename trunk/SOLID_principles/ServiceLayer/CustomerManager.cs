using System.Collections.Generic;
using BusinessObjects;
using DataAccess;

namespace ServiceLayer
{
    public class CustomerManager
    {
        public List<Customer> GetAll()
        {
            var customerDao = new CustomerDataAccessObject();

            var customers = customerDao.FindAllCustomers();
            foreach (var customer in customers)
            {
                var orderManager = new OrderDataAccessObject();
                customer.Orders = orderManager.FindOrdersForCustomer(customer.Id);
            }

            return customers;
        }
    }
}