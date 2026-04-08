using DemoPD.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.Abstractions.Message
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
