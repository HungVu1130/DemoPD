using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken=default);
    }
}
