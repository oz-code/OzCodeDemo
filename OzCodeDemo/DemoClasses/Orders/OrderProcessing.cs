namespace OzCodeDemo.DemoClasses.Orders
{
    public class OrderProcessing
    {
        private readonly ShippingService _shippingService;

        public OrderProcessing(ShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void ShipOrder(OrderInfo orderInfo, Order order)
        {
            var reciever = OrderRepository.GetOrderReciever(orderInfo);

            if (reciever.Id != orderInfo.Customer.Id)
            {
                orderInfo.Customer = reciever;
            }

            _shippingService.SendOrder(orderInfo.Customer, order).Wait();
        }
    }
}