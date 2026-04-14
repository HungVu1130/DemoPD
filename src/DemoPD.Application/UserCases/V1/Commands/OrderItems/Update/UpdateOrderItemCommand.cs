using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Update
{
    public record UpdateOrderItemCommand(Guid OrderItemId,Guid ProductId,Guid OrderId,int Quantity,decimal UnitPrice) : ICommand<Guid>
    {
    }
    public record UpdateOrderItemRequest(Guid ProductId, Guid OrderId, int Quantity, decimal UnitPrice) : ICommand<Guid>
    {
    }
}
