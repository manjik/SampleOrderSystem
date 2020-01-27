using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SampleOrdersWebAPI.Models;

namespace SampleOrdersWebAPI.Tests
{
    class TestSampleOrdersContext : ISampleOrdersContext
    {
        public TestSampleOrdersContext()
        {
            this.Customers = new TestCustomerDbSet();
            this.Orders = new TestOrderDbSet();
        }

        public DbSet<Customer> Customers { get; set;}

        public DbSet<Order> Orders { get; set; }

        public void Dispose()
        {
        }
    }
}
