using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProducts
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, List<GetProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<GetProductResponse>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var response = products.Select(p => new GetProductResponse
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return Result.Success(response);
        }
    }
}
