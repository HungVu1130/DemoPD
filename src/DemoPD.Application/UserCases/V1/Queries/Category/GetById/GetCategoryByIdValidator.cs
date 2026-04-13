using DemoPD.Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Category.GetById
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Khong tim thay danh muc")
                .MustAsync(async (id, cancellationToken) =>
                {
                    var exits = await _categoryRepository.GetByIdAsync(id);
                    return exits != null;
                }).WithMessage("Danh muc khong ton tai");
        }
    }
}
