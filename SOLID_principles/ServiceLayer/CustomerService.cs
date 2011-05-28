using System.Collections.Generic;
using BusinessObjects;

namespace ServiceLayer
{
    public class CustomerService
    {
        public List<CustomerDto> GetAllCustomers()
        {
            var customerManager = new CustomerManager();
            var mapper = new CustomerMapper();

            List<Customer> customers = customerManager.GetAll();
            List<CustomerDto> customerDtos = mapper.Map(customers);

            return customerDtos;
        }
    }
}