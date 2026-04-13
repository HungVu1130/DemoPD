using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Order.GetAll
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery,List<GetOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<List<GetOrderResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            var response = orders.Select(o => new GetOrderResponse
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                OrderTotalAmount = o.TotalAmount,
                OrderStatus = o.Status,
            }).ToList();
            return Result.Success(response);
        }
    }
}
