using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Order.GetAll
{
    public class GetOrdersQuery : IQuery<List<GetOrderResponse>>;
}
