using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.application.services.@interface;
using SmartWorkshopAPI.domain.entities;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

namespace SmartWorkshopAPI.application.services
{
    public class ReadOrderService : IReadOrderService
    {
        IReadOrderRepositoryService _readOrderRepositoryService;
        public ReadOrderService(IReadOrderRepositoryService readOrderRepositoryService ) 
        { 
            _readOrderRepositoryService = readOrderRepositoryService;
        }
        async public Task<Order> GetOrderById(int orderId)
        {
            var order = await _readOrderRepositoryService.GetOrderByIdAsync(orderId);

            return order;
            // throw new NotImplementedException();
        }

        public Task<List<Order>> ListAllOrders()
        {
            var orders =  _readOrderRepositoryService.GetAllOrdersAsync();
            return orders.ContinueWith(t => t.Result.ToList());
            //  throw new NotImplementedException();
        }
    }
}
