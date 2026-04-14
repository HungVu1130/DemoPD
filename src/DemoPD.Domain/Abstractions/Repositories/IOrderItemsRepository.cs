using DemoPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions.Repositories
{
    public interface IOrderItemsRepository
    {
        Task<OrderItem> GetByIdAsync(Guid id);
        Task<List<OrderItem>> GetAllAsync();
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(OrderItem orderItem);
    }
}
