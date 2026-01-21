using SmartWorkshopAPI.application.strategy.@interface;

namespace SmartWorkshopAPI.application.strategy
{
    public class ManualOrderProcessingStrategy : IOrderProcessingStrategy
    {
        public string ProcessOrder(int orderId)
        {
            return $"Order {orderId} is being processed manually.";
        }
    }
}
