﻿using System.Collections.Generic;

namespace BusinessObjects
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}