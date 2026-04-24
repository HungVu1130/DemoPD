using System;
using System.Collections.Generic;

namespace DemoPD.Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
