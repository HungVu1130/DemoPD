using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.Category.Update
{
    public record UpdateCategoryCommand(Guid CategoryId,string Name, string Description) : ICommand<Guid>
    {
    }
    public record UpdateCategoryRequest(string Name, string Description) : ICommand<Guid>;
}
