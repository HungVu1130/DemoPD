using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.OrderItems.GetAll
{
    public class GetOrderItemsQueryHandler : IQueryHandler<GetOrderItemsQuery,List<GetOrderItemsResponse>>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        public GetOrderItemsQueryHandler(IOrderItemsRepository orderItemsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
        }

        public async Task<Result<List<GetOrderItemsResponse>>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemsRepository.GetAllAsync();
            var response = orderItems.Select(p => new GetOrderItemsResponse
            {
                OrderItemId = p.OrderItemId,
                ProductId = p.ProductId,
                OrderId = p.OrderId,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
            }).ToList();
            return Result.Success(response);
        }
    }
}
