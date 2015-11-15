using System;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses.Orders
{
    public interface IShippingCalculator
    {
        DateTime CalculateEta(string origin, Address destination);
    }
}