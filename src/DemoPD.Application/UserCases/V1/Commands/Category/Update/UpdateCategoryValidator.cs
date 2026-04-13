using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Update
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(x=>x.CategoryId).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
