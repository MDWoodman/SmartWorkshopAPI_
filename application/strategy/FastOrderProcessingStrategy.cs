using SmartWorkshopAPI.application.strategy.@interface;

namespace SmartWorkshopAPI.application.strategy
{
    public class FastOrderProcessingStrategy : IOrderProcessingStrategy
    {
        public string ProcessOrder(int orderId)
        {
             return $"Order {orderId} is being processed with Fast Strategy.";

        }
    }
}
