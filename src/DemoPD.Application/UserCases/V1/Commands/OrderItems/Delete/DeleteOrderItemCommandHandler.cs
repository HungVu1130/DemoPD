using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.OrderItems.Delete
{
    public class DeleteOrderItemCommandHandler : ICommandHandler<DeleteOrderItemCommand>
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderItemCommandHandler(IOrderItemsRepository orderItemsRepository, IUnitOfWork unitOfWork)
        {
            _orderItemsRepository = orderItemsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemsRepository.GetByIdAsync(request.OrderItemId);
            _orderItemsRepository.Delete(orderItem);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success();
        }
    }
}
