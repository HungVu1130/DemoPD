using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Create
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.Name,
                Description = request.Description,
            };
            _categoryRepository.Add(category);
            await _unitOfWork.SaveChangeAsync();
            return Result.Success(category.CategoryId);
        }
    }
}
