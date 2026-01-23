using AutoMapper;
using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.application.services.factory.@interface;
using SmartWorkshopAPI.application.services.@interface;
using SmartWorkshopAPI.application.strategy.@interface;
using SmartWorkshopAPI.infrastructure.repositories.@internal;
using static System.Object;

namespace SmartWorkshopAPI.application.services
{
    /// <summary>
    /// Provides write operations for orders: create, update, delete and execute processing strategies.
    /// </summary>
    /// <remarks>
    /// This service coordinates mapping DTOs to domain entities, delegating persistence to
    /// <see cref="IWriteOrderRepositoryService"/>, and selects processing strategies via
    /// <see cref="IOrderProcessingStrategyFactory"/>.
    /// </remarks>
    public class WriteOrderService : IWriteOrderService
    {
        /// <summary>
        /// Repository service responsible for persisting order changes.
        /// </summary>
        private readonly IWriteOrderRepositoryService _writeOrderRepositoryService;

        /// <summary>
        /// Factory used to resolve the order processing strategy by type/name.
        /// </summary>
        private readonly IOrderProcessingStrategyFactory _orderProcessingStrategy;

        /// <summary>
        /// AutoMapper instance used to map DTOs to domain entities.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteOrderService"/> class.
        /// </summary>
        /// <param name="mapper">AutoMapper instance for DTO &lt;-&gt; entity mapping.</param>
        /// <param name="writeOrderRepositoryService">Repository service used to persist order changes.</param>
        /// <param name="orderProcessingStrategyFactory">Factory to obtain order processing strategies.</param>
        public WriteOrderService(IMapper mapper,  IWriteOrderRepositoryService writeOrderRepositoryService , IOrderProcessingStrategyFactory orderProcessingStrategyFactory) 
        { 
            _writeOrderRepositoryService = writeOrderRepositoryService;
            _orderProcessingStrategy = orderProcessingStrategyFactory;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new order from the provided DTO and persists it.
        /// </summary>
        /// <param name="createOrderDto">The DTO describing the order to create.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the identifier
        /// of the newly created order.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="createOrderDto"/> is null.</exception>
        async public Task<int> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<SmartWorkshopAPI.domain.entities.Order>(createOrderDto);
            order.StartOrder();
            var id =  await _writeOrderRepositoryService.AddOrderAsync(order);
            return id;
        }

        /// <summary>
        /// Deletes the order with the specified identifier.
        /// </summary>
        /// <param name="orderId">Identifier of the order to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result is <c>true</c> when the
        /// delete operation completes (this implementation always returns <c>true</c> on completion).
        /// </returns>
        /// <remarks>
        /// The repository is responsible for handling non-existent identifiers and raising appropriate exceptions
        /// or returning silently depending on its implementation.
        /// </remarks>
        async public Task<bool> DeleteOrder(int orderId)
        {
            await _writeOrderRepositoryService.DeleteOrderAsync(orderId);
            return true;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Executes a processing strategy for the specified order and records the chosen strategy on the order.
        /// </summary>
        /// <param name="orderId">Identifier of the order to process.</param>
        /// <param name="strategyType">The strategy type or key used to resolve the processing strategy.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a string result
        /// returned by the strategy's <c>ProcessOrder</c> method.
        /// </returns>
        /// <remarks>
        /// This method:
        /// - Resolves a strategy via <see cref="IOrderProcessingStrategyFactory.GetStrategy(string)"/>.
        /// - Calls the strategy's <c>ProcessOrder</c> synchronously to obtain a result.
        /// - Updates the order's recorded strategy in the repository asynchronously.
        ///
        /// Consumers should be aware that if the requested strategy cannot be resolved, a <see cref="NullReferenceException"/>
        /// or a custom exception may be thrown depending on the factory implementation.
        /// </remarks>
        async public Task<string> ExecuteOrderProcessingStrategy(int orderId, string strategyType)
        {
            var procesStrategyResult = _orderProcessingStrategy.GetStrategy(strategyType).ProcessOrder(orderId);
            var updateStrategyReult = await _writeOrderRepositoryService.UpdateOrderProcessStrategy(orderId, strategyType);

            return procesStrategyResult;
        }

        /// <summary>
        /// Updates an existing order using the provided DTO.
        /// </summary>
        /// <param name="orderId">Identifier of the order to update. (Note: current implementation maps DTO to an order entity; ensure the DTO contains the ID or repository uses other means.)</param>
        /// <param name="updateOrderDto">The DTO containing updated order information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result is <c>true</c> when the
        /// repository reports that one or more records were updated.
        /// </returns>
        async public Task<bool> UpdateOrder(int orderId, UpdateOrderDto updateOrderDto)
        {
            var order = _mapper.Map<SmartWorkshopAPI.domain.entities.Order>(updateOrderDto);
            var id = await _writeOrderRepositoryService.UpdateOrderAsync(order);
            return id > 0;
        }

    }
}
