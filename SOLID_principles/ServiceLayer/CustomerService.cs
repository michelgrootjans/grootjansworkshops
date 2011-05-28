using System.Collections.Generic;
using BusinessObjects;

namespace ServiceLayer
{
    public class CustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            var customerManager = new CustomerManager();
            return customerManager.GetAll();
        }
    }
}