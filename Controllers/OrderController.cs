using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.application.services.@interface;

namespace SmartWorkshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IWriteOrderService _writeOrderService;
        public OrderController(ILogger<OrderController> logger , IWriteOrderService writeOrderService)
        {
            _logger = logger;
            _writeOrderService = writeOrderService;
        }
        [HttpPost("{orderId}/process/{strategyType}")]
        public IActionResult ProcessOrder(int orderId, string strategyType)
        {
            var result = _writeOrderService.ExecuteOrderProcessingStrategy(orderId, strategyType);
            return Ok(result);
        }
        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(CreateOrderDto createOrderDto)
        {
            // Implementation for adding an order goes here
            var newOrderId = await _writeOrderService.CreateOrder(createOrderDto);
            return Ok(newOrderId);
            //return Ok();
        }
}
