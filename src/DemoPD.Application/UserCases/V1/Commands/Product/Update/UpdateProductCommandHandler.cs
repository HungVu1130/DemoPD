using DemoPD.Application.Abstractions.Message;
using DemoPD.Application.UserCases.V1.Queries.Product;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Update
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand,Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository,IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);

                if (product == null)
                {
                    return Result.Failure<Guid>(new Error("Product.NotFound", $"Sản phẩm Id {request.Id} không tồn tại"));
                }
                product.ProductName = request.Name;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.CategoryId = request.CategoryId;

                await _unitOfWork.SaveChangeAsync(cancellationToken);
                return Result.Success(product.ProductId);
            }
            catch (DbException ex)
            {
                return Result.Failure<Guid>(new Error("2", "Khoa ngoai khong chinh xac"));
            }
        }
    }
}
