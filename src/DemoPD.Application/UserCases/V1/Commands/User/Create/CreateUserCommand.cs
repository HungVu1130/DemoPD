using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.User.Create
{
    public record CreateUserCommand(string UserName, string Email, string Password
        ) : ICommand<Guid>
    {
    }
}
