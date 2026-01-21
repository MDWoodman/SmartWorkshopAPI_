namespace SmartWorkshopAPI.application.Dto
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ReadOrderItemDto> Items { get; set; }
        

    }
}