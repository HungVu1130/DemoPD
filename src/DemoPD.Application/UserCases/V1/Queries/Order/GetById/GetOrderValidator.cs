using DemoPD.Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Order.GetById
{
    public class GetOrderValidator : AbstractValidator<GetOrderByIdQuery>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            RuleFor(x => x.OrderId).NotEmpty()
                .MustAsync(async (id, CancellationToken) =>
                {
                    var exits = await _orderRepository.GetByIdAsync(id);
                    return exits != null;
                });
            
        }
    }
}
