using DemoPD.Application.UserCases.V1.Commands.Product.Create;
using DemoPD.Application.UserCases.V1.Commands.Product.Delete;
using DemoPD.Application.UserCases.V1.Commands.Product.Update;
using DemoPD.Application.UserCases.V1.Queries.Product.GetProductById;
using DemoPD.Application.UserCases.V1.Queries.Product.GetProducts;
using DemoPD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DemoPD.Presentation.V1.Products
{
    public class ProductEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/products", async (
                [FromBody] CreateProductCommand command,
                ISender sender) =>
            {
                var result = await sender.Send(command);

                return result.IsFailure
                    ? Results.BadRequest(new { Error = result.Error.Code, Message = result.Error.Message })
                    : Results.Ok(result);
            })
            .WithTags("Products");

            app.MapGet("api/v1/products", async (ISender sender) =>
            {
                var query = new GetProductQuery();

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
            })
            .WithTags("Products");

            app.MapGet("api/v1/products/{id:guid}", async (ISender sender, Guid id) =>
            {
                var query = new GetProductByIdQuery(id);
                var result = await sender.Send(query);
                return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.NotFound(new { Error = result.Error.Code, Message = result.Error.Message });
                    })
        .WithTags("Products");

            app.MapPut("api/v1/products/{id:guid}", async ([FromBody] UpdateProductRequest request, ISender sender, Guid id) =>
            {
                var command = new UpdateProductCommand(id, request.Name, request.Price, request.Stock,request.CategoryId);
                var  result = await sender.Send(command);
                return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
            }).WithTags("Products");

            app.MapDelete("api/v1/products/{id:guid}", async (ISender sender, Guid id) =>
            {
                var request = new DeleteProductCommand(id);
                var result = await sender.Send(request);
                return result.IsSuccess ? Results.NoContent() : Results.BadRequest(result.Error);
            }).WithTags("Products");
        }
    }
}