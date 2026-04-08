using DemoPD.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync();
    }
}
