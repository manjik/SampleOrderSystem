using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
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

        public async Task<IActionResult> Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}