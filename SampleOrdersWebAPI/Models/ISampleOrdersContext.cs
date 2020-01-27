using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Models
{
    public interface ISampleOrdersContext : IDisposable 
    {
        DbSet<Customer> Customers { get; }
        DbSet<Order> Orders { get; }
    } 
}
