using SmartWorkshopAPI.application.Dto;

namespace SmartWorkshopAPI.application.services.@interface
{
    /// <summary>
    /// Defines write operations for orders (create, update, delete) and orchestration
    /// of order processing strategies.
    /// </summary>
    /// <remarks>
    /// Implementations are responsible for persisting order changes and selecting/executing
    /// a processing strategy identified by <c>strategyType</c>.
    /// </remarks>
    public interface IWriteOrderService
    {
        /// <summary>
        /// Executes a processing strategy for the specified order.
        /// </summary>
        /// <param name="orderId">Identifier of the order to process.</param>
        /// <param name="strategyType">The strategy identifier (for example: "Fast", "Premium", "Manual").</param>
        /// <returns>
        /// A string describing the outcome of the processing operation (for example a status message
        /// or strategy-specific result).
        /// </returns>
        public Task<string> ExecuteOrderProcessingStrategy(int orderId, string strategyType);

        /// <summary>
        /// Creates a new order from the provided DTO.
        /// </summary>
        /// <param name="createOrderDto">Data transfer object containing the information required to create an order.</param>
        /// <returns>
        /// A <see cref="Task{Int32}"/> representing the asynchronous operation. The task result contains
        /// the identifier of the newly created order.
        /// </returns>
        public Task<int> CreateOrder(CreateOrderDto createOrderDto);

        /// <summary>
        /// Updates an existing order with values from the DTO.
        /// </summary>
        /// <param name="orderId">Identifier of the order to update.</param>
        /// <param name="updateOrderDto">DTO containing updated order values.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> representing the asynchronous operation. The task result is <c>true</c>
        /// if the update succeeded; otherwise <c>false</c>.
        /// </returns>
        public Task<bool> UpdateOrder(int orderId, UpdateOrderDto updateOrderDto);

        /// <summary>
        /// Deletes the specified order.
        /// </summary>
        /// <param name="orderId">Identifier of the order to delete.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> representing the asynchronous operation. The task result is <c>true</c>
        /// if the deletion succeeded; otherwise <c>false</c>.
        /// </returns>
        public Task<bool> DeleteOrder(int orderId);
    }
}
