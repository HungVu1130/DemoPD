using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Update
{
    public class UpdateOrderItemCommandHandler : ICommandHandler<UpdateOrderItemCommand,Guid>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderItemCommandHandler(IOrderItemsRepository orderItemsRepository, IUnitOfWork unitOfWork)
        {
            _orderItemsRepository = orderItemsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemsRepository.GetByIdAsync(request.OrderItemId);
            orderItem.ProductId = request.ProductId;
            orderItem.OrderId = request.OrderId;
            orderItem.Quantity = request.Quantity;
            orderItem.UnitPrice = request.UnitPrice;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success(orderItem.OrderItemId);
        }
    }
}
