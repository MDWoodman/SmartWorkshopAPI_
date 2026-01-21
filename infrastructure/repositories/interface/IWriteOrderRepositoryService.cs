using SmartWorkshopAPI.domain.entities;

namespace SmartWorkshopAPI.infrastructure.repositories.@internal
{
    public interface IWriteOrderRepositoryService
    {
        Task<int> AddOrderAsync(Order order);
        Task<int> UpdateOrderAsync(Order order);
        Task<int> DeleteOrderAsync(int orderId);
    }
}
