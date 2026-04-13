using DemoPD.Application.UserCases.V1.Commands.Category.Create;
using DemoPD.Application.UserCases.V1.Commands.Order.Create;
using DemoPD.Application.UserCases.V1.Commands.Order.Delete;
using DemoPD.Application.UserCases.V1.Commands.Order.Update;
using DemoPD.Application.UserCases.V1.Queries.Category.GetAll;
using DemoPD.Application.UserCases.V1.Queries.Order.GetAll;
using DemoPD.Application.UserCases.V1.Queries.Order.GetById;
using DemoPD.Domain.Shared;
using DemoPD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Presentation.V1.Orders
{
    public class OrdersAPI : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/order", async ([FromBody] CreateOrderCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return result.IsFailure ? Results.BadRequest(new { Error = result.Error.Code, Message = result.Error.Message })
                : Results.Ok(result);
            }).WithTags("Order");

            app.MapGet("/api/v1/order", async (ISender sender) =>
            {
                var query = new GetOrdersQuery();
                var result = await sender.Send(query);
                return result.IsFailure ? Results.BadRequest(new { Error = result.Error.Code, Message = result.Error.Message })
                : Results.Ok(result);
            }).WithTags("Order");

            app.MapGet("/api/v1/order/{id:guid}", async (ISender sender, Guid Id) =>
            {
                var query = new GetOrderByIdQuery(Id);
                var result = await sender.Send(query);
                return result.IsFailure ? Results.BadRequest(new {Error = result.Error.Code,Message = result.Error.Message}) 
                : Results.Ok(result);
            }).WithTags("Order");

            app.MapPut("/api/v1/order/{id:guid}", async (ISender sender,[FromBody] UpdateOrderRequest request, Guid id) =>
            {
                var command = new UpdateOrderCommand(
                    id,request.OrderDate,request.OrderTotalAmount,request.OrderStatus
                    );
                var result = await sender.Send(command);
                return result.IsFailure ? Results.BadRequest(new { Error = result.Error.Code, Message = result.Error.Message })
                : Results.Ok(result);
            }).WithTags("Order");

            app.MapDelete("/api/v1/order/", async (ISender sender, Guid id) =>
            {
                var query = new DeleteOrderCommand(id);
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Order");
        }
    }
}
