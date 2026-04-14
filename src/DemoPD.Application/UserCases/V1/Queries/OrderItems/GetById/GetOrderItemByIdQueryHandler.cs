using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.OrderItems.GetById
{
    public class GetOrderItemByIdQueryHandler : IQueryHandler<GetOrderItemByIdQuery,GetOrderItemsResponse>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        public GetOrderItemByIdQueryHandler(IOrderItemsRepository orderItemsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
        }

        public async Task<Result<GetOrderItemsResponse>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemsRepository.GetByIdAsync(request.OrderItemId);
            var response = new GetOrderItemsResponse
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
            return Result.Success(response);
        }
    }
}
