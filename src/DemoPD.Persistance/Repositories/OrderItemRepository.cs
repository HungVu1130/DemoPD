using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance.Repositories
{
    public class OrderItemRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(OrderItem orderItem) => _context.OrderItems.Add(orderItem);

        public void Delete(OrderItem orderItem) => _context.OrderItems.Remove(orderItem);

        public async Task<List<OrderItem>> GetAllAsync() => await _context.OrderItems.ToListAsync();

        public async Task<OrderItem> GetByIdAsync(Guid id) => await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);

        public void Update(OrderItem orderItem) => _context.OrderItems.Update(orderItem);
    }
}
