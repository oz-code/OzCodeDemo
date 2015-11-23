using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.Orders;

namespace OzCodeDemo._06.WhenSetBreakDemo
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "WhenSetBreak")]
    public class WhenSetBreakDemo : IOzCodeDemo
    {
        public void Start()
        {
            Logger.LogMessage("--- Start ---");
            var customers = CustomersRepository.LoadCustomersFromDb().Where(c => c.Address.Country == "US").Take(20);

            foreach (var sender in customers)
            {
                var orders = OrderRepository.GetOrdersForCustomer(sender.Id);
                if (orders.Any())
                {
                    Logger.LogMessage("Start sending orders for customer: " + sender.Id );
                }
                
                foreach (var order in orders)
                {
                    ProcessOrder(order, sender);
                }
            }

            MessageBox.Show(string.Join(Environment.NewLine, Logger.GetAllMessages()));
        }

        private static void ProcessOrder(Order order, Customer sender)
        {
            var orderInfo = new OrderInfo(order, sender);

            var shippingService = new ShippingService("US");
            var orderProcessing= new OrderProcessing(shippingService);

            orderProcessing.ShipOrder(orderInfo, order);

            SendInvoice(orderInfo);
        }

        private static void SendInvoice(OrderInfo orderInfo)
        {
            BillingService billingService = new BillingService();

            billingService.SendInvoice(orderInfo);
        }
    }
}
