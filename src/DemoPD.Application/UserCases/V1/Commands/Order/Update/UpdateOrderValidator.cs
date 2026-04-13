using DemoPD.Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Update
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderValidator(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
            RuleFor(x => x.OrderId)
                .MustAsync(async (id, CancellationToken) =>
                {
                    var exits = await _orderRepository.GetByIdAsync(id);
                    return exits != null;
                });
            RuleFor(x => x.OrderDate).NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddMinutes(1));
            RuleFor(x=> x.OrderTotalAmount).NotEmpty();
            RuleFor(x=>x.OrderStatus).NotEmpty();
        }
    }
}
