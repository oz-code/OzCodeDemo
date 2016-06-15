using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses.Orders
{
    public class ShippingService
    {
        private static readonly Random Random = new Random();

        private readonly string _originCountry;

        private readonly Dictionary<ShippingMethod, IShippingCalculator> _shippingCalculators = new Dictionary<ShippingMethod, IShippingCalculator>
        {
            {ShippingMethod.Ground, new GroundShippingCalculator() },
            {ShippingMethod.Overnight, new OvernightShippingCalculator() },
            {ShippingMethod.Priority, new PriorityShippingCalculator() },
            {ShippingMethod.TwoDay, new TwoDayShippingCalculator() },
        };

        public ShippingService(string originCountry)
        {
            _originCountry = originCountry;
        }

        public async Task SendOrder(Customer customer, Order order)
        {
            try
            {
                var orderEta = CalculateOrderEta(order, customer.Address);

                await SendAsync(order, customer.Address);

                await NotifyCustomerOfSuccess(customer, order.ID, orderEta);

            }
            catch (IllegalOrderException exc)
            {
                NotifyCustomerOfDelay(customer, order).Wait();

                throw new OrderProcessingException("Failed to deliver order " + order.ID, exc);
            }
        }

        private async Task SendAsync(Order order, Address address)
        {
            await Task.FromResult(false);
        }

        private async Task NotifyCustomerOfDelay(Customer customer, Order order)
        {
            var message =
                string.Format("Dear {0} {1}, Your order {2} cannot be delivered - please contact customer support",
                    customer.FirstName, customer.Surname, order.ID);

            await EmailClient.Send(customer.EmailAddress, "Failed delivering order", message);
        }

        private async Task NotifyCustomerOfSuccess(Customer customer, int orderId, DateTime orderEta)
        {
            var message = string.Format("Dear {0} {1}, Your order {2} has been shipped and expected to arrive at: {3}",
                customer.FirstName, customer.Surname, orderId, orderEta);

            await EmailClient.Send(customer.EmailAddress, "Order sent", message);
        }

        private DateTime CalculateOrderEta(Order order, Address destination)
        {
            return _shippingCalculators[order.ShippingMethod].CalculateEta(_originCountry, destination);

        }
    }
}