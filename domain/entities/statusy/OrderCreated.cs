namespace SmartWorkshopAPI.domain.entities.statusy
{
    public class OrderCreated : OrderStatus
    {

        public override string Name { get => "Created"; }

        public override void StartOrder(Order order)
        {
             order.SetStatus(Name);
        }
    }
}
