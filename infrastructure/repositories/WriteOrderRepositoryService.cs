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
        async public Task<int> AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            return await  _dbContext.SaveChangesAsync();

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
    }
}
