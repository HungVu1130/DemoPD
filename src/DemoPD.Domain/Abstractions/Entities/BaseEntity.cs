using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Domain.Abstractions.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
