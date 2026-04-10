using DemoPD.Application.DependencyInjection.Extensions;
using DemoPD.Application.Middleware;
using DemoPD.Persistance.DependencyInjection.Extensions;
using DemoPD.Presentation.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddEndpoints(typeof(DemoPD.Presentation.Abstractions.IEndpoint).Assembly);
builder.Services.AddApplication();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapEndpoints();

app.Run();
