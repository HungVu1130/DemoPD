using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Category.GetAll
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery,List<GetCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<GetCategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var response = categories.Select(p => new GetCategoryResponse
            {
                CategoryId = p.CategoryId,
                Name = p.CategoryName,
                Description = p.Description,
            }).ToList();
            return Result.Success(response);
        }

    }
}
