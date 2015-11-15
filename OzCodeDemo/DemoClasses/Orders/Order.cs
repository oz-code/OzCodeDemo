namespace OzCodeDemo.DemoClasses.Orders
{
    public class Order
    {
        public int ID { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public ShippingMethod ShippingMethod { get; set; }
    }
}