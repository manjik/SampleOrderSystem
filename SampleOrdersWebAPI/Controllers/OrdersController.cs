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
    public class OrdersController : ControllerBase
    {
        private readonly SampleOrdersContext _context;

        protected IOrdersRepository _ordersRepo;

        protected OrdersController()
        {
            _ordersRepo = GetRepository();
        }

        public OrdersController(SampleOrdersContext context)
        {
            _context = context;
            _ordersRepo = GetRepository();
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _ordersRepo.GetAllAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var allOrders = await _ordersRepo.GetAllAsync();
            var order = allOrders.FirstOrDefault(c => c.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                await _ordersRepo.Update(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExistsAsync(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _ordersRepo.Create(order);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var allOrders = await _ordersRepo.GetAllAsync();
            var order = allOrders.FirstOrDefault(c => c.Id == id);
            
            if (order == null)
            {
                return NotFound();
            }

            await _ordersRepo.Delete(order);

            return order;
        }

        private async Task<bool> OrderExistsAsync(int id)
        {
            var allCustomers = await _ordersRepo.GetAllAsync();

            return allCustomers.Any(e => e.Id == id);
        }


        protected virtual IOrdersRepository GetRepository()
        {
            if (_context != null)
                return new OrdersRepository(_context);
            else
                return null;
        }
    }
}
