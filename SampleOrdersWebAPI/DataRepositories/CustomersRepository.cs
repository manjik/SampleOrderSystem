using Microsoft.EntityFrameworkCore;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
    public interface IEntityRepository<T>
    {
        Task<List<T>> GetAllAsync();
    }

    public interface ICustomersRepository : IEntityRepository<Customer>
    {
    }

    public class CustomersRepository : ICustomersRepository
    {
        private readonly SampleOrdersContext _context;

        public CustomersRepository(SampleOrdersContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(c => c.Orders).ToListAsync();
        }
    }
}