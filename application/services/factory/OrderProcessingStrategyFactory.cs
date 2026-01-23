using SmartWorkshopAPI.application.services.factory.@interface;
using SmartWorkshopAPI.application.strategy;
using SmartWorkshopAPI.application.strategy.@interface;

namespace SmartWorkshopAPI.application.services.factory
{
    internal class OrderProcessingStrategyFactory : IOrderProcessingStrategyFactory
    {
        IOrderProcessingStrategy _orderProcessingStrategy;

        /// <summary>
        /// Create a new <see cref="OrderProcessingStrategyFactory"/>.
        /// </summary>
        /// <param name="orderProcessingStrategy">
        /// A default or fallback <see cref="IOrderProcessingStrategy"/> instance that
        /// can be returned when the factory does not create a new instance. This
        /// parameter may be used by consumers that prefer an already-resolved instance.
        /// </param>
        public OrderProcessingStrategyFactory(IOrderProcessingStrategy orderProcessingStrategy)
        {
            _orderProcessingStrategy = orderProcessingStrategy;
        }

        /// <summary>
        /// Returns an <see cref="IOrderProcessingStrategy"/> implementation matching the provided
        /// <paramref name="strategyType"/> key.
        /// </summary>
        /// <param name="strategyType">A string identifying which strategy to create. Valid values: "Manual", "Express", "Premium".</param>
        /// <returns>An instance of <see cref="IOrderProcessingStrategy"/> corresponding to <paramref name="strategyType"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="strategyType"/> is not recognized.</exception>
        /// <remarks>
        /// This method instantiates concrete strategy types directly. Consider using
        /// DI container registrations or a map-based factory if new strategy types are
        /// added frequently.
        /// </remarks>
        public IOrderProcessingStrategy GetStrategy(string strategyType)
        {
            switch (strategyType.ToLower())
            {
                case "manual":
                    return new ManualOrderProcessingStrategy();
                    break;
                case "express":
                    return new FastOrderProcessingStrategy();
                    break;
                case "premium":
                    return new PremiumOrderProcessingStrategy();
                    break;
                default:
                    throw new ArgumentException("Invalid strategy type");
            }
            return _orderProcessingStrategy;
        }
    }
}