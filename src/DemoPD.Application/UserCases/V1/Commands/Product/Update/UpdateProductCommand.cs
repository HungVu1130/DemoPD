using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Update
{
    public record UpdateProductCommand(Guid Id, string Name,decimal Price,int Stock) : ICommand<Guid>
    {
    }
    public record UpdateProductRequest(string Name, decimal Price, int Stock) : ICommand<Guid>
    {
        
    }
}
