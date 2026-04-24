using DemoPD.Application.Abstractions.Authentication;
using DemoPD.Application.DependencyInjection.Extensions;
using DemoPD.Application.Middleware;
using DemoPD.Domain.Abstractions.Repositories;
using DemoPD.Infrastructure;
using DemoPD.Infrastructure.Extensions;
using DemoPD.Persistance.DependencyInjection.Extensions;
using DemoPD.Persistance.Repositories;
using DemoPD.Presentation.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddEndpoints(typeof(DemoPD.Presentation.Abstractions.IEndpoint).Assembly);
builder.Services.AddApplication();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasherRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Run();
