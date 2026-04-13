using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Update
{
    public record UpdateOrderCommand(Guid OrderId,DateTime OrderDate, decimal OrderTotalAmount, string OrderStatus) : ICommand<Guid>
    {
    }
    public record UpdateOrderRequest(DateTime OrderDate, decimal OrderTotalAmount, string OrderStatus) : ICommand<Guid>
    {
    }
}
