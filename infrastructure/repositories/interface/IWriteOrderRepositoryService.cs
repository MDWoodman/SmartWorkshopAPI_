using SmartWorkshopAPI.domain.entities;

namespace SmartWorkshopAPI.infrastructure.repositories.@internal
{
    /// <summary>
    /// Defines write operations for <see cref="Order"/> entities against the data store.
    /// Implementations are responsible for persisting changes for create, update and delete operations.
    /// </summary>
    public interface IWriteOrderRepositoryService
    {
        /// <summary>
        /// Adds a new <see cref="Order"/> to the data store asynchronously.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> to add. Must not be <c>null</c>.</param>
        /// <returns>
        /// A <see cref="Task{Int32}"/> representing the asynchronous operation.
        /// The task result is typically the newly created order identifier (for example, the database identity value)
        /// or a non-negative value indicating success depending on the repository implementation.
        /// </returns>
        Task<int> AddOrderAsync(Order order);

        /// <summary>
        /// Updates an existing <see cref="Order"/> in the data store asynchronously.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> containing updated values. Must not be <c>null</c>.</param>
        /// <returns>
        /// A <see cref="Task{Int32}"/> representing the asynchronous operation.
        /// The task result is typically the number of records affected (for example, 1 when the update succeeds, 0 when no matching record was found).
        /// </returns>
        Task<int> UpdateOrderAsync(Order order);

        /// <summary>
        /// Deletes the order with the specified identifier from the data store asynchronously.
        /// </summary>
        /// <param name="orderId">The identifier of the order to delete.</param>
        /// <returns>
        /// A <see cref="Task{Int32}"/> representing the asynchronous operation.
        /// The task result is typically the number of records removed (for example, 1 when deletion succeeds, 0 when no matching record was found).
        /// </returns>
        Task<int> DeleteOrderAsync(int orderId);

        /// <summary>
        /// Updates the processing strategy value for the specified order asynchronously.
        /// </summary>
        /// <param name="orderId">The identifier of the order to update.</param>
        /// <param name="processStrategy">The new process strategy value to apply.</param>
        /// <returns>
        /// A <see cref="Task{Boolean}"/> representing the asynchronous operation.
        /// The task result is <c>true</c> when the update succeeds; otherwise <c>false</c>.
        /// </returns>
        Task<bool> UpdateOrderProcessStrategy(int orderId, string processStrategy);
    }
}
