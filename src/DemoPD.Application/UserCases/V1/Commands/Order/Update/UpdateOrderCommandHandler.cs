using DemoPD.Application.Abstractions.Message;
using DemoPD.Domain.Abstractions;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Order.Update
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand,Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository,IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Guid>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            order.OrderDate = request.OrderDate;
            order.TotalAmount = request.OrderTotalAmount;
            order.Status = request.OrderStatus;
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return Result.Success(request.OrderId);
        }
    }
}
