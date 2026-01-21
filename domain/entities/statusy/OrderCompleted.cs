namespace SmartWorkshopAPI.domain.entities.statusy
{
    public class OrderCompleted : OrderStatus
    {
        public override string Name { get => "Completed"; }
        public override void CompleteOrder(Order order)
        {
            order.SetStatus(Name);
        }
       
    }
}
