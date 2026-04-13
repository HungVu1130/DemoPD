using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Create
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.OrderDate).NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1));
            RuleFor(x => x.TotalAmount).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
