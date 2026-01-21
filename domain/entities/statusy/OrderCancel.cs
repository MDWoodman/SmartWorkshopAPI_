namespace SmartWorkshopAPI.domain.entities.statusy
{
    public class OrderCancel : OrderStatus
    {
        public override string Name { get => "Cancelled"; }
        public override void CancelOrder(Order order)
        {
            order.SetStatus(Name);
        }
    }
}
