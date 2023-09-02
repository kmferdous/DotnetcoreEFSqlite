using Microsoft.Extensions.Configuration;
using Transactions.Api;
using Transactions.Api.Configs;
using Transactions.Api.Middlewares;
using Transactions.Application;
using Transactions.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var configuration = AppConfigurationBuilder.BuildConfiguration(env);

// Add services to the container.
builder.Services.AddInfrastructure(configuration)
    .AddApplication()
    .AddApi();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var appInitializer = new ApplicationInitializer();
appInitializer.Initialize(configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
