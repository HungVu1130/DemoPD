using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> GetByIdAsync(Guid id) => await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        public async Task<List<Order>> GetAllAsync() => await _context.Orders.ToListAsync();
        public void Add(Order order) => _context.Orders.Add(order);
        public void Update(Order order) => _context.Orders.Update(order);
        public void Delete(Order order) => _context.Orders.Remove(order);
    }
}
