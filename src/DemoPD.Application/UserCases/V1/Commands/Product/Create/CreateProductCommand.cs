using DemoPD.Application.Abstractions.Message;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Create
{
    public record CreateProductCommand(
        string Name,
        decimal Price,
        int Stock,
        Guid CategoryId
        ) : ICommand<Guid>;
}
