using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Create
{
    public class CreateOrderItemsCommandHandler : ICommandHandler<CreateOrderItemsCommand,Guid>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderItemsCommandHandler(IOrderItemsRepository orderItemsRepository,IUnitOfWork unitOfWork) 
        {
            _orderItemsRepository = orderItemsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new Domain.Entities.OrderItem
            {
                OrderItemId = Guid.NewGuid(),
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
            };
            _orderItemsRepository.Add(orderItem);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success(orderItem.OrderItemId);
        }
    }
}
