using System.Collections.Generic;
using BusinessObjects;

namespace ServiceLayer
{
    public class CustomerMapper
    {
        public List<CustomerDto> Map(List<Customer> customers)
        {
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
            return result;
        }
    }
}