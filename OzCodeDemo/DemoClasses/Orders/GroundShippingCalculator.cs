using System;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses.Orders
{
    internal class GroundShippingCalculator : IShippingCalculator
    {
        public DateTime CalculateEta(string origin, Address destination)
        {
            if (origin != destination.Country)
            {
                throw new IllegalOrderException(string.Format("Cannot use selected shipping method to ship to {0}, {1}", destination.City, destination.Country));
            }

            return DateTime.Now.AddDays(14);
        }
    }
}