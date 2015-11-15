using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._04.ConditionalBreakpoints
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "ConditionalBreakpoints")]
    public class ConditionalBreakpointsDemo : IOzCodeDemo
    {
        private readonly PaymentValidation _validation = new PaymentValidation();

        public void Start()
        {
            IEnumerable<Customer> approvedCustomers;
            var allCustomers = CustomersRepository.LoadCustomersFromDb();

            approvedCustomers = _validation.Validate(allCustomers);

            SendOrders(approvedCustomers);
        }

        private void SendOrders(IEnumerable<Customer> approvedCustomers)
        {
            foreach (var customer in approvedCustomers)
            {
                Trace.WriteLine(customer.FirstName + " " + customer.Surname);
            }
        }
    }
}