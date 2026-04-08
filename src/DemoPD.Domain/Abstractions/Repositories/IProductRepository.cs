using DemoPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
