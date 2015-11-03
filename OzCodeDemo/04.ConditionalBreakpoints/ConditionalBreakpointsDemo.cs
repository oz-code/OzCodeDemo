using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media.Converters;
using OzCodeDemo.DemoClasses;

namespace OzCodeDemo._04.ConditionalBreakpoints
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "ConditionalBreakpoints")]
    public class ConditionalBreakpointsDemo : IOzCodeDemo
    {
        private readonly PaymentValidation _validation = new PaymentValidation();

        public void Start()
        {
            IEnumerable<Customer> approvedCustomers = null;
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