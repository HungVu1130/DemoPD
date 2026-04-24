using DemoPD.Application.UserCases.V1.Commands.User.Create;
using DemoPD.Application.UserCases.V1.Commands.User.Login;
using DemoPD.Domain.Shared;
using DemoPD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Presentation.V1
{
    public class UsersAPI : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/user", async (ISender sender, [FromBody] CreateUserCommand command) =>
            {
                var result = await sender.Send(command);
                return result.IsFailure ? Results.BadRequest(new {Error = result.Error.Code,Message = result.Error.Message})
                :Results.Ok(result) ;
            });

            app.MapPost("/api/v1/auth", async ([FromBody] LoginCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return result.IsFailure ? Results.Json(result.Error, statusCode: 401) : Results.Ok(new { Token = result.Value });
            }).WithName("Login");
        }
    }
}
