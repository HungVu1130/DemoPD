using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Entities;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Category.GetById
{
    public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery,GetCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<GetCategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null) 
            {
                return Result.Failure<GetCategoryResponse>(new Error("Category.NotFound", $"Khong tim thay san pham co Id = {request.CategoryId}"));
            }
            var response = new GetCategoryResponse
            {
                CategoryId = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description,
            };
            return Result.Success(response);
        }
    }
}
