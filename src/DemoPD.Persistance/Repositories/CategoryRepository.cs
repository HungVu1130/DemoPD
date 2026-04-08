using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DemoPD.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> GetByIdAsync(Guid id) => await _context.Categories.FirstOrDefaultAsync(x=>x.CategoryId==id);
        public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public void Add(Category category) => _context.Categories.Add(category);
        public void Update(Category category) => _context.Categories.Update(category);
        public void Delete(Category category) => _context.Categories.Remove(category);
    }
}
