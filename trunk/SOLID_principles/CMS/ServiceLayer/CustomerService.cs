using System.Collections.Generic;
using DataAccess;

namespace ServiceLayer
{
    public class CustomerService
    {
        public List<CustomerDto> GetAllCustomers()
        {
            var customerDao = new CustomerDataAccessObject();
            var orderDao = new OrderDataAccessObject();

            var customers = customerDao.FindAllCustomers();
            foreach (var customer in customers)
            {
                customer.Orders = orderDao.FindOrdersForCustomer(customer.Id);
            }

            var customerDtos = new List<CustomerDto>();
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
                customerDtos.Add(customerDto);
            }

            return customerDtos;
        }
    }
}