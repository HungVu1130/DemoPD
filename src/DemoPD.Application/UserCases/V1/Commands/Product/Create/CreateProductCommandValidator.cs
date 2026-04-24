using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Product.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bat buoc phai co ten san pham");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Gia san pham phai lon hon 0");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("So luong ton kho khong duoc nho hon 0");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Vui long chon dung danh muc cho san pham");
        }
    }
}
