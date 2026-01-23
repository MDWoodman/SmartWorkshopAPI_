using Microsoft.EntityFrameworkCore;
using SmartWorkshopAPI.domain.entities;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

namespace SmartWorkshopAPI.infrastructure.repositories
{
    public class WriteOrderRepositoryService : IWriteOrderRepositoryService
    {
        private readonly SmartWorkshopDbContext _dbContext;
        public WriteOrderRepositoryService(SmartWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new <see cref="Order"/> entity to the database context and persists the change.
        /// </summary>
        /// <param name="order">The <see cref="Order"/> to add. The instance will be tracked by the DbContext and may be updated with database-generated values after save.</param>
        /// <returns>
        /// A <see cref="Task{Int32}"/> representing the asynchronous operation. The result contains the number of state entries written to the database.
        /// </returns>
        /// <remarks>
        /// This method adds the provided entity to the DbContext in the Added state and calls <c>SaveChangesAsync()</c> to persist the change.
        /// Any database-generated values (for example, identity primary keys) will be populated on the <paramref name="order"/> instance once the task completes.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException">If <paramref name="order"/> is null.</exception>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">If an error occurs while saving changes to the database.</exception>
        async public Task<int> AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await  _dbContext.SaveChangesAsync();
            return order.OrderId;


        }

        async public Task<int> DeleteOrderAsync(int orderId)
        {
              _dbContext.Orders.Remove( new Order { OrderId = orderId } );
              return await _dbContext.SaveChangesAsync();
            // throw new NotImplementedException();
        }

        async public Task<int> UpdateOrderAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            return await _dbContext.SaveChangesAsync();
            // throw new NotImplementedException();
        }

        async public Task<bool> UpdateOrderProcessStrategy(int orderId, string processStrategy)
        {
           await _dbContext.Orders
                .Where(o => o.OrderId == orderId)
                .ExecuteUpdateAsync(setters => 
                    setters.SetProperty(
                        o => o.ProcessStrategy, 
                        o => processStrategy
                    )
                );

            return true;
        }
    }
}
