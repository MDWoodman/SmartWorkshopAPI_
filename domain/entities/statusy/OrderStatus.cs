namespace SmartWorkshopAPI.domain.entities.statusy
{
    public abstract class OrderStatus
    {
        public abstract string Name  { get; }
        public virtual void StartOrder(Order order)
        {
            throw new InvalidOperationException("Cannot start the order in the current state.");
        }
        public virtual void CompleteOrder(Order order)
        {
            throw new InvalidOperationException("Cannot complete the order in the current state.");
        }
        public virtual void CancelOrder(Order order)
        {
            throw new InvalidOperationException("Cannot cancel the order in the current state.");
        }
        public virtual void ShipOrder(Order order)
        {
            throw new InvalidOperationException("Cannot ship the order in the current state.");
        }
    }
}
