using DemoPD.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.Abstractions.Message
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result>
        where TCommand : ICommand
    {
    }
    public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
