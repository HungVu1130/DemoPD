using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) 
            {
                return Result.Failure(new Error("Product.NotFound", $"San pham khong ton tai"));
            }
            _productRepository.Delete(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return Result.Success();
        }
    }
}
