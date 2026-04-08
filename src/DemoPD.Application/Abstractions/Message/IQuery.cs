using DemoPD.Domain.Shared;
using MediatR;


namespace DemoPD.Application.Abstractions.Message
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
