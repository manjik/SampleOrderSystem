using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleOrdersWebAPI.DataRepositories;
using SampleOrdersWebAPI.Models;

namespace SampleOrdersWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SampleOrdersContext _context;

        protected ICustomersRepository _customersRepo;
        protected ICustomersRepository _CustomersRepo => _customersRepo ?? (_customersRepo = GetRepository());

        protected CustomersController()
        {
        }

        public CustomersController(SampleOrdersContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _CustomersRepo.GetAllAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var allCustomers = await _CustomersRepo.GetAllAsync();
            var customer = allCustomers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // GET: api/Customers/noorders
        [Route("noorders")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerWithoutOrders()
        {
            var allCustomers = await _CustomersRepo.GetAllAsync();
            return allCustomers.Where(c => c.Orders == null || c.Orders.Count == 0).ToList();
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _CustomersRepo.Update(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExistsAsync(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _CustomersRepo.Create(customer);
            
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var allCustomers = await _CustomersRepo.GetAllAsync();
            var customer = allCustomers.FirstOrDefault(c => c.Id == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            await _CustomersRepo.Delete(customer);

            return customer;
        }

        private async Task<bool> CustomerExistsAsync(int id)
        {
            var allCustomers = await _CustomersRepo.GetAllAsync();

            return allCustomers.Any(e => e.Id == id);
        }

        protected virtual ICustomersRepository GetRepository()
        {
            if (_context != null)
                return new CustomersRepository(_context);
            else
                return null;
        }
    }
}
