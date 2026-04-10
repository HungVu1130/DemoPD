using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DemoPD.Application.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e); 
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is FluentValidation.ValidationException validationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var errors = validationException.Errors
                    .Select(x => new { Field = x.PropertyName, Message = x.ErrorMessage });

                var responsePayload = new { Title = "Validation Error", Errors = errors };
                var json = JsonSerializer.Serialize(responsePayload);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var responsePayload = new { Title = "Server Error", Message = exception.Message };
                var json = JsonSerializer.Serialize(responsePayload);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
