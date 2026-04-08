using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Product
{
    public record GetProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price {  get; set; }
        public int Stock {  get; set; }

    }
}
