using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Create
{
    public record CreateCategoryCommand
        (
            string Name,
            string Description
        ) : ICommand<Guid>;
}
