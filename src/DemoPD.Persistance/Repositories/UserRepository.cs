using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByIdAsync(Guid Id) => await _context.Users.FirstOrDefaultAsync(x=>x.Id==Id);
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User> GetByNameAsync(string UserName) => await _context.Users
            .Include(u=>u.Roles)
            .FirstOrDefaultAsync(x => x.UserName == UserName);
        public void Add(User user) => _context.Users.Add(user); 
        public void Update(User user) => _context.Users.Update(user);
        public void Delete(User user) => _context.Users.Remove(user);
    }
}
