using SmartWorkshopAPI.domain.entities;

namespace SmartWorkshopAPI.infrastructure.repositories.@internal
{
    public interface IReadOrderRepositoryService
    {
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<string> GetOrderStatusAsync(int orderId);
    }
}
