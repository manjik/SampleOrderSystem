using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleOrdersWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.DataRepositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SampleOrdersContext _context;

        public OrdersRepository(SampleOrdersContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<int> Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;

            return await _context.SaveChangesAsync(); 
        }

        public async Task<int> Create(Order order)
        {
            _context.Orders.Add(order);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Order order)
        {
            _context.Orders.Remove(order);

            return await _context.SaveChangesAsync();
        }
    }
}