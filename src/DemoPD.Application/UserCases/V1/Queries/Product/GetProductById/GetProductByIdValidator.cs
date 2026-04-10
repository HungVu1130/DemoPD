using DemoPD.Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Product.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdValidator(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
            RuleFor(x => x.ProductId).
                NotEmpty().WithMessage("Khong tim thay san pham")
                .MustAsync(async (id, cancellationToken) =>
                {
                    var exits = await _productRepository.GetByIdAsync(id);
                    return exits != null;
                }).WithMessage("San pham khong ton tai");
          
        }
    }
}
