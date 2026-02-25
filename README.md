# SmartWorkshopAPI

## Overview

SmartWorkshopAPI is a REST API for managing workshop orders. It is built with ASP.NET Core 8, Entity Framework Core 8, SQLite and AutoMapper. The application allows creating, reading, updating and deleting orders, and supports dynamic order processing through the Strategy design pattern resolved via a Factory.

## Architecture

The solution follows a layered architecture with four layers:

- Controllers — HTTP endpoints, request/response handling
- Application — business logic, services, DTOs, AutoMapper profiles, strategy and factory
- Domain — entities (Order, OrderItem), status value objects, domain methods
- Infrastructure — EF Core database context, repository implementations, SQLite persistence

## Domain Entities

Order contains the following properties: OrderId, CustomerName, OrderDate, OrderStatus, TotalAmount, TotalFee and a collection of OrderItem. The Order entity exposes domain methods: StartOrder, CompleteOrder, CancelOrder, ShipOrder, AddItem and RemoveItem.

OrderItem contains OrderItemId and a foreign key OrderId pointing to the parent Order. The relationship uses cascade delete.

## Services

Services are split into read and write responsibilities:

- IWriteOrderService — CreateOrder, UpdateOrder, DeleteOrder, ExecuteOrderProcessingStrategy
- IReadOrderService — GetOrderById, ListAllOrders, GetOrderStatus

Each service interface has a corresponding implementation (WriteOrderService, ReadOrderService) that delegates persistence to repository services.

## Repositories

Repositories follow the same read/write split:

- IWriteOrderRepositoryService — AddOrderAsync, UpdateOrderAsync, DeleteOrderAsync, UpdateOrderProcessStrategy
- IReadOrderRepositoryService — GetAllOrdersAsync, GetOrderByIdAsync, GetOrderStatusAsync

Both repositories use SmartWorkshopDbContext which is configured with SQLite (smartworkshop.db).

## Design Patterns

### Strategy Pattern

Order processing logic is encapsulated behind the IOrderProcessingStrategy interface with a single method ProcessOrder(int orderId). Three concrete implementations exist:

- ManualOrderProcessingStrategy — selected with the key "Manual"
- FastOrderProcessingStrategy — selected with the key "Express"
- PremiumOrderProcessingStrategy — selected with the key "Premium"

### Factory Pattern

OrderProcessingStrategyFactory implements IOrderProcessingStrategyFactory. It receives a strategy type string and returns the matching IOrderProcessingStrategy instance. If the key is not recognized, an ArgumentException is thrown.

### Request Flow

OrderController receives a POST request with orderId and strategyType. It calls WriteOrderService.ExecuteOrderProcessingStrategy which uses OrderProcessingStrategyFactory.GetStrategy to resolve the correct strategy. The resolved strategy executes ProcessOrder and the result is returned to the client.

## API Endpoints

POST api/order/add-order — creates a new order from a CreateOrderDto containing CustomerName, TotalAmount and a list of items.

POST api/order/{orderId}/process/{strategyType} — processes an existing order using the specified strategy (Manual, Express or Premium).

## Dependency Injection

All services are registered with Scoped lifetime in Program.cs:

- IWriteOrderRepositoryService -> WriteOrderRepositoryService
- IReadOrderRepositoryService -> ReadOrderRepositoryService
- IOrderProcessingStrategy -> ManualOrderProcessingStrategy, FastOrderProcessingStrategy, PremiumOrderProcessingStrategy
- IOrderProcessingStrategyFactory -> OrderProcessingStrategyFactory
- IWriteOrderService -> WriteOrderService
- IReadOrderService -> ReadOrderService

AutoMapper is registered by scanning the assembly containing OrderMapperProfile.

## Database

The application uses SQLite with the connection string "Data Source=smartworkshop.db". Entity Framework Core manages schema through migrations. Primary keys on Order and OrderItem are auto-generated. Order has a one-to-many relationship with OrderItem using cascade delete.

## NuGet Packages

- AutoMapper.Extensions.Microsoft.DependencyInjection 8.1.1
- Microsoft.EntityFrameworkCore.Sqlite 8.0.22
- Microsoft.EntityFrameworkCore.Tools 8.0.23

## How to Run

Clone the repository. Run dotnet restore to install dependencies. Run dotnet ef database update to apply migrations. Run dotnet run to start the API. The server will listen on HTTPS on the port shown in the console output.
