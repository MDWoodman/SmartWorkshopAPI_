using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWorkshopAPI.application.Dto;
using SmartWorkshopAPI.application.services.@interface;

namespace SmartWorkshopAPI.Controllers
{
    /// <summary>
    /// API controller responsible for write operations related to orders.
    /// Exposes endpoints to process an existing order using a specified processing strategy
    /// and to create a new order.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IWriteOrderService _writeOrderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="logger">Logger instance for logging controller activity.</param>
        /// <param name="writeOrderService">Service used to perform write operations for orders.</param>
        public OrderController(ILogger<OrderController> logger, IWriteOrderService writeOrderService)
        {
            _logger = logger;
            _writeOrderService = writeOrderService;
        }

        /// <summary>
        /// Processes an existing order using the specified strategy.
        /// </summary>
        /// <param name="orderId">Identifier of the order to process.</param>
        /// <param name="strategyType">Name of the processing strategy to apply (e.g., "Standard", "Expedite").</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the result of the processing operation.
        /// Returns 200 OK with the result payload when processing completes.
        /// </returns>
        /// <remarks>
        /// Route: POST api/order/{orderId}/process/{strategyType}
        /// This method delegates processing to <see cref="IWriteOrderService.ExecuteOrderProcessingStrategy(int, string)"/>.
        /// </remarks>
        [HttpPost("{orderId}/process/{strategyType}")]
        public IActionResult ProcessOrder(int orderId, string strategyType)
        {
            var result = _writeOrderService.ExecuteOrderProcessingStrategy(orderId, strategyType);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new order from the provided DTO.
        /// </summary>
        /// <param name="createOrderDto">Data transfer object containing information required to create the order.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the newly created order's identifier.
        /// Returns 200 OK with the new order id when creation succeeds.
        /// </returns>
        /// <remarks>
        /// Route: POST api/order/add-order
        /// This method delegates creation to <see cref="IWriteOrderService.CreateOrder(CreateOrderDto)"/>.
        /// </remarks>
        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(CreateOrderDto createOrderDto)
        {
            // Implementation for adding an order goes here
            var newOrderId = await _writeOrderService.CreateOrder(createOrderDto);
            return Ok(newOrderId);
            //return Ok();
        }

    }
}
