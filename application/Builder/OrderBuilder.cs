using SmartWorkshopAPI.domain.entities;

namespace SmartWorkshopAPI.application.Builder
{
    public class OrderBuilder
    {
        private Order _order;
        public OrderBuilder() { }
       
        public OrderBuilder SetOrderId(int orderId)
        {
            _order.OrderId = orderId;
            return this;
        }
        public OrderBuilder SetCustomerName(string customerName)
        {
            _order.CustomerName = customerName;
            return this;
        }
        public OrderBuilder SetOrderDate(DateTime orderDate)
        {
            _order.OrderDate = orderDate;
            return this;
        }
        public OrderBuilder SetTotalAmount(decimal totalAmount)
        {
            _order.TotalAmount = totalAmount;
            return this;
        }
        public OrderBuilder SetTotalFee(decimal totalFee)
        {
            _order.TotalFee = totalFee;
            return this;
        }
        public OrderBuilder SetItems(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                _order.AddItem(item);
            }
            return this;
        }
        public Order Build()
        {
            return _order;
        }


    }
}
