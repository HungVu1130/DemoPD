using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Create
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ten danh muc khong duoc de trong");
        }
    }
}
