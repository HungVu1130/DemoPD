using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Update
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ten san pham khong duoc de trong");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Gia san pham khong duoc nho hon hoac bang 0");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("So luong ton kho khong duoc nho hon 0");
        }
    }
}
