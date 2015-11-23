using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo._06.WhenSetBreakDemo;

namespace OzCodeDemo.DemoClasses.Orders
{
    public class OrderRepository
    {
        static readonly Random Random = new Random();
        static int _maxOrderId;

        public static IEnumerable<Order> GetOrdersForCustomer(int customerId)
        {
            var numOfOrders = Random.Next(0, 5);

            for (int i = 0; i < numOfOrders; i++)
            {
                yield return new Order
                {
                    ID = Interlocked.Increment(ref _maxOrderId),
                    Item = ItemList[Random.Next(5)],
                    Quantity = Random.Next(1, 100),
                    ShippingMethod = ShippingMethods[Random.Next(0, ShippingMethods.Length - 1)]
                };
            }
        }

        private static readonly string[] ItemList = new[] { "XBox One", "iPad", "LG G2", "PS4", "HTC1", "Nokia 1020" };
        private static readonly ShippingMethod[] ShippingMethods = Enum.GetValues(typeof(ShippingMethod)).Cast<ShippingMethod>().ToArray();

        public static Customer GetOrderReciever(OrderInfo orderInfo)
        {
            if (Random.Next(0, 10) % 5 == 0)
            {
                var customerPool = CustomersRepository.LoadCustomersFromDb().Where(c => c.Address.Country == "US");

                return customerPool.ElementAt(Random.Next(0, customerPool.Count() - 1));
            }

            return orderInfo.Customer;
        }
    }
}