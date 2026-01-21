using Microsoft.EntityFrameworkCore;
using SmartWorkshopAPI.domain.entities;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

namespace SmartWorkshopAPI.infrastructure.repositories
{
    public class ReadOrderRepositoryService : IReadOrderRepositoryService
    {
        private readonly SmartWorkshopDbContext _dbContext;
        public ReadOrderRepositoryService(SmartWorkshopDbContext smartWorkshopDbContext)
        { 
            _dbContext = smartWorkshopDbContext;
        }
        async public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        async public Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }
    }
}
