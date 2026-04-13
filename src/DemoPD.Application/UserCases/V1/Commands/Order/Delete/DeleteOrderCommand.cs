using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Delete
{
    public record DeleteOrderCommand(Guid OrderId) : ICommand
    {
    }
}
