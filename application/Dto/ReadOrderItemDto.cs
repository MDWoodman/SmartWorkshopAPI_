namespace SmartWorkshopAPI.application.Dto
{
    public class ReadOrderItemDto
    {
        public Guid OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;
    }
}