using DemoPD.Application.Abstractions.Message;
using MediatR;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProducts
{
    public record GetProductQuery() : IQuery<List<GetProductResponse>>
    {
    }

    
}
