using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Create
{
    public record CreateOrderCommand(DateTime OrderDate, decimal TotalAmount, string Status) : ICommand<Guid>;
}
