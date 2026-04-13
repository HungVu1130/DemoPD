using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Order
{
    public record GetOrderResponse
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
