using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Delete
{
    public record DeleteOrderItemCommand(Guid OrderItemId) : ICommand
    {
    }
}
