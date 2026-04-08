using DemoPD.Domain.Entities;

namespace DemoPD.Domain.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllAsync();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
