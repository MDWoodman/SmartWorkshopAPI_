using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.domain.entities;

namespace SmartWorkshopAPI.application.services.@interface
{   
    /// <summary>
    /// Provides read-only operations for orders.
    /// </summary>
    /// <remarks>
    /// Implementations should expose query methods that retrieve order data without performing modifications.
    /// Methods are asynchronous and intended for use by callers that only need to read order information.
    /// </remarks>
    interface IReadOrderService
    {
        // Define read operations for orders (e.g., get by ID, list all)
        // Implementations should provide methods to retrieve order data without modifying it

        /// <summary>
        /// Asynchronously retrieves an order by its identifier.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{ReadOrderDto}"/> that completes with a <see cref="ReadOrderDto"/> representing the order.
        /// The returned value may be <c>null</c> if the order is not found (implementation-dependent).
        /// </returns>
        public Task<Order> GetOrderById(int orderId);

        /// <summary>
        /// Asynchronously retrieves all orders.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{List{ReadOrderDto}}"/> that completes with a list of <see cref="ReadOrderDto"/>.
        /// The list may be empty if no orders exist.
        /// </returns>
        public Task<List<Order>> ListAllOrders();



    }
}
