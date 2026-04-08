using DemoPD.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.Abstractions.Message
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
