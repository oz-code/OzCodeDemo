using System;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses.Orders
{
    internal class OvernightShippingCalculator : IShippingCalculator
    {
        public DateTime CalculateEta(string origin, Address destination)
        {
            return DateTime.Now.AddHours(12);
        }
    }
}