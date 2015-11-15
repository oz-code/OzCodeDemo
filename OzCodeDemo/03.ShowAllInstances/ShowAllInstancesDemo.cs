using System.ComponentModel.Composition;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.Invoices;

namespace OzCodeDemo._03.ShowAllInstances
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "ShowAllInstances")]
    public class ShowAllInstancesDemo : IOzCodeDemo
    {
        private readonly CustomerController _controller = new CustomerController();

        public void Start()
        {
            var invoiceService = new InvoiceService();

            var currCustomer = _controller.GetCurrentCustomer();

            invoiceService.SendInvoice(currCustomer);

            invoiceService.Shutdown();
        }
    }
}
