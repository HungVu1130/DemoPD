using DemoPD.Application.UserCases.V1.Commands.OrderItems.Create;
using DemoPD.Application.UserCases.V1.Commands.OrderItems.Delete;
using DemoPD.Application.UserCases.V1.Commands.OrderItems.Update;
using DemoPD.Application.UserCases.V1.Queries.OrderItems.GetAll;
using DemoPD.Application.UserCases.V1.Queries.OrderItems.GetById;
using DemoPD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Presentation.V1.OrderItems
{
    public class OrderItemsAPI : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/orderItem", async (ISender sender, [FromBody] CreateOrderItemsCommand command) =>
            {
                var result = await sender.Send(command);
                return Results.Ok(result);
            }).WithTags("Order Item");

            app.MapGet("/api/v1/orderItem", async (ISender sender) =>
            {
                var query = new GetOrderItemsQuery();
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Order Item");

            app.MapGet("/api/v1/orderItem/{id:guid}", async (ISender sender, Guid id) =>
            {
                var query = new GetOrderItemByIdQuery(id);
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Order Item");

            app.MapPut("/api/v1/orderItem/{id:guid}", async (ISender sender,Guid id, [FromBody] UpdateOrderItemRequest request) =>
            {
                var query = new UpdateOrderItemCommand(id, request.ProductId, request.OrderId, request.Quantity, request.UnitPrice);
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Order Item");

            app.MapDelete("/api/v1/delele/{id:guid}", async (ISender sender,Guid id) =>
            {
                var query = new DeleteOrderItemCommand(id);
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Order Item");
        }
    }
}
