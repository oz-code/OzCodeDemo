using System;
using System.Collections.Generic;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo.DemoClasses
{
    class PaymentValidation
    {
        Dictionary<string, IPaymentGateway> _paymentGateways = new Dictionary<string, IPaymentGateway>
        {
            {"Visa", new VisaPaymentGateway()},
            {"MasterCard", new MasterCardPaymentGateway()}

        };

        public IEnumerable<Customer> Validate(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (CanOrderFromSite(customer))
                {
                    yield return customer;
                }
            }
        }

        private bool CanOrderFromSite(Customer customer)
        {
            var isValidAge = customer.Age > 18;

            var isApproved = CheckWithPaymentGateway(customer);

            return isApproved && isValidAge;
        }

        private bool CheckWithPaymentGateway(Customer customer)
        {
            if (_paymentGateways.ContainsKey(customer.CCType))
            {
                return _paymentGateways[customer.CCType].Approve(customer);
            }

            return false;
        }
    }

    interface IPaymentGateway
    {
        bool Approve(Customer customer);
    }

    class MasterCardPaymentGateway : IPaymentGateway
    {
        readonly Random _random = new Random();

        public bool Approve(Customer customer)
        {
            return _random.Next(1, 100) > 35;
        }
    }

    class VisaPaymentGateway : IPaymentGateway
    {
        readonly Random _random = new Random();
        public bool Approve(Customer customer)
        {
            return _random.Next(1, 100) > 15;
        }
    }
}

