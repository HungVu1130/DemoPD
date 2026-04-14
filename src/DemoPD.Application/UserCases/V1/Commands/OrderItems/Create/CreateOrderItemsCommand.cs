using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Create
{
    public record CreateOrderItemsCommand(Guid OrderId,Guid ProductId,int Quantity, decimal UnitPrice) : ICommand<Guid>
    {
    }
}
