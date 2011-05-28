using System.Collections.Generic;
using BusinessObjects;

namespace ServiceLayer
{
    public class CustomerService
    {
        public List<CustomerDto> GetAllCustomers()
        {
            var customerManager = new CustomerManager();
            List<Customer> customers = customerManager.GetAll();

            var result = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                var customerDto = new CustomerDto();
                customerDto.Id = customer.Id;
                customerDto.Name = customer.Name;
                foreach (var order in customer.Orders)
                {
                    var orderDto = new OrderDto();
                    orderDto.Id = order.Id;
                    orderDto.Name = order.Name;
                    customerDto.Orders.Add(orderDto);
                }
                result.Add(customerDto);
            }
            List<CustomerDto> customerDtos = result;

            return customerDtos;
        }
    }
}