using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using DemoPD.Domain.Shared;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProducts
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, List<GetProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductQueryHandler(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<GetProductResponse>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var response = products
                .Select(p => new GetProductResponse
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                }).ToList();

            return Result.Success(response);
        }
    }
}
