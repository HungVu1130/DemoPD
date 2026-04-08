using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Update
{
    internal class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand,Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return Result.Failure<Guid>(new Error("Category.NotFound", "Khong tim thay san pham"));
            }
            category.CategoryName = request.Name;
            category.Description = request.Description;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success(category.CategoryId);
        }
    }
}
