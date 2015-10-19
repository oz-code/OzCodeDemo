using System.CodeDom;
using System.ComponentModel.Composition;
using System.Linq;
using System.Diagnostics;
using OzCodeDemo.DemoClasses;

namespace OzCodeDemo._01._Reveal
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "Reveal")]
    public class RevealDemo : IOzCodeDemo
    {
        public void Start()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            var customersFromParis = customers.Where(customer => customer.Address.City == "Paris").ToList();

            foreach (var customer in customersFromParis)
            {
                SendOverseasPackage(customer);
            }
        }

        private void SendOverseasPackage(Customer customer)
        {
            if (customer.Address.Country == "US")
            {
                // Shouldn't get here
                Debugger.Break();
            }

            // Send package
        }
    }
}
