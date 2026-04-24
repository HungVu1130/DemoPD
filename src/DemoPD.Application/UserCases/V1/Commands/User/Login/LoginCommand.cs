using DemoPD.Application.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Commands.User.Login
{
    public record LoginCommand(string UserName, string Password) : ICommand<string>
    {
    }
}
