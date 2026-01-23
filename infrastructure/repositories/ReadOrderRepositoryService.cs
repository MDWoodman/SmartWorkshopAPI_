using Microsoft.EntityFrameworkCore;
using SmartWorkshopAPI.domain.entities;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

namespace SmartWorkshopAPI.infrastructure.repositories
{
    /// <summary>
    /// Read-only repository service for <see cref="Order"/> entities.
    /// Provides methods to retrieve orders from the underlying <see cref="SmartWorkshopDbContext"/>.
    /// </summary>
    public class ReadOrderRepositoryService : IReadOrderRepositoryService
    {
        /// <summary>
        /// Entity Framework Core database context used to access persistence.
        /// Injected via constructor and used for read operations against the <c>Orders</c> DbSet.
        /// </summary>
        private readonly SmartWorkshopDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOrderRepositoryService"/> class.
        /// </summary>
        /// <param name="smartWorkshopDbContext">
        /// The <see cref="SmartWorkshopDbContext"/> used to query order data. Must not be null.
        /// </param>
        public ReadOrderRepositoryService(SmartWorkshopDbContext smartWorkshopDbContext)
        { 
            _dbContext = smartWorkshopDbContext;
        }

        /// <summary>
        /// Asynchronously retrieves all orders from the data store.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that resolves to an <see cref="IEnumerable{Order}"/>
        /// containing all persisted orders. The sequence may be empty if no orders exist.
        /// </returns>
        async public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a single order by its identifier.
        /// </summary>
        /// <param name="orderId">The identifier of the order to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{Order}"/> that resolves to the matching <see cref="Order"/> if found; otherwise <c>null</c>.
        /// </returns>
        async public Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public Task<string> GetOrderStatusAsync(int orderId)
        {
            return _dbContext.Orders
                .Where(o => o.OrderId == orderId)
                .Select(o => o.OrderStatus)
                .FirstOrDefaultAsync()!;

        }
    }
}
