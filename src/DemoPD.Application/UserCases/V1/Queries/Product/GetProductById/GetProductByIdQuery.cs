using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProductById
{
    public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductResponse>;
}
