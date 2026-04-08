using DemoPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<List<Order>> GetAllAsync();
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
