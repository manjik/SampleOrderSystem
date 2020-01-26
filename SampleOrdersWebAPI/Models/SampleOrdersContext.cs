using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Models
{
    public class SampleOrdersContext : DbContext
    {
        public SampleOrdersContext(DbContextOptions<SampleOrdersContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
