using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProductById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery,GetProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<GetProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product is null)
            {
                return Result.Failure<GetProductResponse>(
                    new Error("Product.NotFound", $"Sản phẩm với ID {request.ProductId} không tồn tại."));
            }
            var response = new GetProductResponse
            {
                Id = product.ProductId,
                Name = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
            };
            return Result.Success(response);
        }
    }
}
