using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.OrderItems
{
    public record GetOrderItemsResponse
    {
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice {  get; set; }
    }
}
