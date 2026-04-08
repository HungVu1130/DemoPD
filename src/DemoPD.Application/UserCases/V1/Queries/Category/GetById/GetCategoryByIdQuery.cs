using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Category.GetById
{
    public record GetCategoryByIdQuery(Guid CategoryId) : IQuery<GetCategoryResponse>
    {
    }
}
