using DemoPD.Application.UserCases.V1.Commands.Category.Create;
using DemoPD.Application.UserCases.V1.Commands.Category.Delete;
using DemoPD.Application.UserCases.V1.Commands.Category.Update;
using DemoPD.Application.UserCases.V1.Queries.Category;
using DemoPD.Application.UserCases.V1.Queries.Category.GetAll;
using DemoPD.Application.UserCases.V1.Queries.Category.GetById;
using DemoPD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DemoPD.Presentation.V1.Categories
{
    public class ProductEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/category", async (ISender sender, [FromBody] CreateCategoryCommand command) =>
            {
                var result = await sender.Send(command);
                return result.IsFailure ? Results.BadRequest(new { Error = result.Error.Code, Message = result.Error.Message })
                : Results.Ok(result);
            }).WithTags("Category");

            app.MapGet("api/v1/category", async (ISender sender) =>
            {
                var query = new GetCategoriesQuery();
                var result = await sender.Send(query);
                if(result.IsFailure)
                {
                    return Results.NotFound(new
                    {
                        Error = result.Error.Code,
                        Message = result.Error.Message
                    });
                }
                return Results.Ok(result);
            }).WithTags("Category");

            app.MapGet("api/v1/category/{id:guid}", async (ISender sender, Guid id) =>
            {
                var query = new GetCategoryByIdQuery(id);
                var result = await sender.Send(query);
                if (result.IsFailure)
                {
                    return Results.NotFound(new
                    {
                        Error = result.Error.Code,
                        Message = result.Error.Message
                    });
                }
                return Results.Ok(result);
            }).WithTags("Category");

            app.MapPut("api/v1/category/{id:guid}", async (ISender sender, Guid id, [FromBody] UpdateCategoryRequest request) =>
            {
                var command = new UpdateCategoryCommand(id,
                    request.Name,
                    request.Description
                    );
                var result = await sender.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).WithTags("Category");

            app.MapDelete("api/v1/category/{id:guid}", async (ISender sender, Guid id) =>
            {
                var query = new DeleteCategoryCommand(id);
                var result = await sender.Send(query);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result.Error);
            }).WithTags("Category");
        }
    }

}
