using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Create
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return Result.Failure<Guid>(new Error("Product.NameEmpty", "Ten san pham khong duoc de trong"));
            }
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            var product = new Domain.Entities.Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId=request.CategoryId

            };
            _productRepository.Add(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success(product.ProductId);
        }
    }
}
