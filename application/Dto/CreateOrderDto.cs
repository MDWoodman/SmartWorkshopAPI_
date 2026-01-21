namespace SmartWorkshopAPI.application.Dto
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

        public List<CreateOrderItemDto> Items { get; set; }

    }
}