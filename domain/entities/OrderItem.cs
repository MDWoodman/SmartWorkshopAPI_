namespace SmartWorkshopAPI.domain.entities
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
        public OrderItem() { }
        public OrderItem(Guid orderItemid, int v, string description, decimal price, int quantity)
        {
            OrderItemId = orderItemid;
            Description = description;
            Price = price;
            Quantity = quantity;
        }


    }
}