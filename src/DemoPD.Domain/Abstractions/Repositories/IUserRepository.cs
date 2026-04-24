using DemoPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid Id);
        Task<List<User>> GetAllAsync();
        Task<User> GetByNameAsync(string UserName);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
