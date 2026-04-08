using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Delete
{
    public record DeleteProductCommand(Guid Id) : ICommand;
}
