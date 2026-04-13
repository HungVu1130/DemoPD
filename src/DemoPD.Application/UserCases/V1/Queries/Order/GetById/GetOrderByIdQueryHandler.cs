using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Order.GetById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery,GetOrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<GetOrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            var response = new GetOrderResponse
            {
                OrderDate = order.OrderDate,
                OrderTotalAmount = order.TotalAmount,
                OrderStatus = order.Status,
            };
            return Result.Success(response);
        }
    }
}
