namespace SmartWorkshopAPI.domain.entities.statusy
{
    public class OrderShip : OrderStatus
    {
        public override string Name { get => "Shipped"; }
        public override void ShipOrder(Order order)
        {
            order.SetStatus(Name);
        }
    }
    
}
