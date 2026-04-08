using System;
using System.Collections.Generic;

namespace DemoPD.Domain.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
