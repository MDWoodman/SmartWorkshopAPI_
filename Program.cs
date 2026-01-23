using SmartWorkshopAPI.application.Mapper;
using SmartWorkshopAPI.application.services;
using SmartWorkshopAPI.application.services.factory.@interface;
using SmartWorkshopAPI.application.services.@interface;
using SmartWorkshopAPI.infrastructure.repositories;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IWriteOrderRepositoryService , WriteOrderRepositoryService>();
builder.Services.AddScoped<IReadOrderRepositoryService , ReadOrderRepositoryService>();
builder.Services.AddScoped<SmartWorkshopAPI.application.strategy.@interface.IOrderProcessingStrategy, SmartWorkshopAPI.application.strategy.ManualOrderProcessingStrategy>();
builder.Services.AddScoped<SmartWorkshopAPI.application.strategy.@interface.IOrderProcessingStrategy, SmartWorkshopAPI.application.strategy.FastOrderProcessingStrategy>();
builder.Services.AddScoped<SmartWorkshopAPI.application.strategy.@interface.IOrderProcessingStrategy, SmartWorkshopAPI.application.strategy.PremiumOrderProcessingStrategy>();
builder.Services.AddScoped<IOrderProcessingStrategyFactory, SmartWorkshopAPI.application.services.factory.OrderProcessingStrategyFactory>();

builder.Services.AddScoped<IWriteOrderService , WriteOrderService>();
builder.Services.AddScoped<IReadOrderService , ReadOrderService>();
builder.Services.AddAutoMapper(typeof(OrderMapperProfile).Assembly);
builder.Services.AddDbContext<SmartWorkshopAPI.infrastructure.repositories.SmartWorkshopDbContext>();





var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
