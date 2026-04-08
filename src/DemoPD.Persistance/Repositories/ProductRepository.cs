using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetByIdAsync(Guid id) => await _context.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        public void Add(Product product) => _context.Products.Add(product);
        public void Update(Product product) => _context.Products.Update(product);
        public void Delete(Product product) => _context.Products.Remove(product);
    }
}
