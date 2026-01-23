using SmartWorkshopAPI.application.strategy.@interface;

namespace SmartWorkshopAPI.application.services.factory.@interface
{
    /// <summary>
    /// Factory contract for resolving an <see cref="IOrderProcessingStrategy"/> by a strategy identifier.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface are responsible for returning the concrete strategy
    /// that encapsulates a specific order processing behavior (for example: "Manual", "Express", "Premium").
    /// Using a factory decouples consumers from concrete strategy implementations and makes it easier
    /// to add or change strategies without modifying callers.
    /// </remarks>
    public interface IOrderProcessingStrategyFactory
    {
        /// <summary>
        /// Returns an <see cref="IOrderProcessingStrategy"/> that corresponds to the provided <paramref name="strategyType"/>.
        /// </summary>
        /// <param name="strategyType">
        /// The strategy identifier used to select the desired processing strategy.
        /// Typical values are case-sensitive names such as "Manual", "Express", or "Premium".
        /// </param>
        /// <returns>
        /// A concrete implementation of <see cref="IOrderProcessingStrategy"/> implementing the requested behavior.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Implementations should throw this exception when an unsupported or unrecognized <paramref name="strategyType"/> is provided.
        /// </exception>
       public IOrderProcessingStrategy GetStrategy(string strategyType);
    }
}
