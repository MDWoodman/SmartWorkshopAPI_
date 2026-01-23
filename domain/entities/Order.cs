using SmartWorkshopAPI.domain.entities.statusy;

namespace SmartWorkshopAPI.domain.entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public string ProcessStrategy { get; set; }
        public decimal TotalFee { get; set; }

        private List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items;

        public Order() { }
        public Order(int orderid, string customerName, DateTime orderDate, decimal totalAmount, decimal totalFee, List<OrderItem> items)
        {
            OrderId = orderid;
            CustomerName = customerName;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            TotalFee = totalFee;
            _items = items;
        }

        public void AddItem(OrderItem item)
        {
            var itemsList = Items.ToList();
            itemsList.Add(item);
            _items = itemsList;
        }

        public void RemoveItem(OrderItem item)
        {
            var itemsList = Items.ToList();
            itemsList.Remove(item);
            _items = itemsList;
        }

        public void StartOrder()
        {
             this.OrderStatus=(new OrderCreated()).Name;
        }
        public void CompleteOrder()
        {
            // Logic to complete the order
        }
        public void CancelOrder()
        {
            // Logic to cancel the order
            this.OrderStatus = (new OrderCancel()).Name;

        }
        public void ShipOrder()
        {
            // Logic to ship the order
            this.OrderStatus = (new OrderShip()).Name;
        }

        internal void SetStatus(string name)
        {
            OrderStatus = name;
        }
    }
}
