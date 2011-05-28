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
            List<Customer> customers;
            using (var transaction = customerDao.BeginTransaction())
            {
                var orderManager = new OrderDataAccessObject((SuperDuperSqlConnection) transaction.Connection);
                
                customers = customerDao.FindAllCustomers();
                foreach (var customer in customers)
                {
                    customer.Orders = orderManager.FindOrdersForCustomer(customer.Id);
                }

                transaction.Commit();
            }

            return customers;
        }
    }
}