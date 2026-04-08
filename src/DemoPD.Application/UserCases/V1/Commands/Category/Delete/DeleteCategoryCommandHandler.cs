using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Delete
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return Result.Failure(new Error("Category.NotFound", $"Khong tim thay san pham co Id = {request.CategoryId}"));
            }
            _categoryRepository.Delete(category);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success();
        }
    }
}
