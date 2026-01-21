using AutoMapper;
using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.application.services.@interface;
using SmartWorkshopAPI.application.strategy.@interface;
using SmartWorkshopAPI.infrastructure.repositories.@internal;

namespace SmartWorkshopAPI.application.services
{
    public class WriteOrderService : IWriteOrderService
    {
        private readonly IWriteOrderRepositoryService _writeOrderRepositoryService;
        private readonly IOrderProcessingStrategyFactory orderProcessingStrategy
        private readonly IMapper _mapper;
        public WriteOrderService(IMapper mapper,  IWriteOrderRepositoryService writeOrderRepositoryService) 
        { 
            _writeOrderRepositoryService = writeOrderRepositoryService;
            _mapper = mapper;
        }
        async public Task<int> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<SmartWorkshopAPI.domain.entities.Order>(createOrderDto);
            var id =  await _writeOrderRepositoryService.AddOrderAsync(order);
            return id;
        }

        async public Task<bool> DeleteOrder(int orderId)
        {
            await _writeOrderRepositoryService.DeleteOrderAsync(orderId);
            return true;
            //throw new NotImplementedException();
        }

        public string ExecuteOrderProcessingStrategy(int orderId, string strategyType)
        {
           
        }

        public Task<bool> UpdateOrder(int orderId, UpdateOrderDto updateOrderDto)
        {
            throw new NotImplementedException();
        }
    }
}
