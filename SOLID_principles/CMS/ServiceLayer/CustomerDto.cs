using System.Collections.Generic;

namespace ServiceLayer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderDto> Orders { get; set; }

        public CustomerDto()
        {
            Orders = new List<OrderDto>();
        }
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}