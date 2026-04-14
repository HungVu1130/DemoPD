using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.OrderItems.GetById
{
    public record GetOrderItemByIdQuery(Guid OrderItemId) : IQuery<GetOrderItemsResponse>
    {
    }
}
