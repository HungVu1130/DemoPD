using System;
using System.Collections.Generic;

namespace DemoPD.Domain.Entities;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
