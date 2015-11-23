using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.Orders;

namespace OzCodeDemo._05.ExceptionTrail
{
    [Export(typeof (IOzCodeDemo))]
    [ExportMetadata("Demo", "ExceptionTrail")]
    public class ExceptionTrailDemo : IOzCodeDemo
    {
        public void Start()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            var shippingService = new ShippingService("US");

            try
            {
                Parallel.ForEach(customers, customer =>
                {
                    var orders = OrderRepository.GetOrdersForCustomer(customer.Id);

                    var tasks = orders.Select(order => shippingService.SendOrder(customer, order)).ToArray();

                    Task.WaitAll(tasks);
                });
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }
    }
} 
