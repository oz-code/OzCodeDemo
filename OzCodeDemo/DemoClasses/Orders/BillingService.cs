namespace OzCodeDemo.DemoClasses.Orders
{
    public class BillingService
    {
        public void SendInvoice(OrderInfo orderInfo)
        {
            Logger.LogMessage("Sent invoice to customer: " + orderInfo.Customer.Id);
        }
    }
}