using System;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses.Orders
{
    internal class PriorityShippingCalculator : IShippingCalculator
    {
        public DateTime CalculateEta(string origin, Address destination)
        {
            return DateTime.Now.AddDays(2);
        }
    }
}