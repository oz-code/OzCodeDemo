using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._10.Predict
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "Predict")]
    public class Predict : IOzCodeDemo
    {
        const int MaxEmailLength = 250;

        public void Start()
        {
            var customers = LoadCustomersFromDb();

            Debugger.Break();

            foreach (var customer in customers)
            {
                switch (customer.Gender)
                {
                    case Gender.Male:
                        if (customer.Address.Country == "France" ||
                            customer.Address.Country == "Canada" ||
                            customer.GetYearlyEarnings(2014) > 10000 ||
                            customer.CCType == "Visa")
                        {
                            SendGift(customer);
                        }
                        else 
                        {
                            SendThankYouLetter(customer);
                        }
                        break;
                    case Gender.Female:
                        SendGift(customer);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }



            if (customers.Any(c => c.CCType == "MasterKard") &&
                customers.All(c => c.FirstName == null))
            {
                SendBill(customers);
            }

        }


        private void SendThankYouLetterInternal(string email)
        {
            // TODO :)
        }

        private void SendGift(Customer customer)
        {
            if (customer.Address.City == "Chicago")
            {
                SendThankYouLetterInternal(customer.EmailAddress);
            }
        }

        private void SendBill(object customers)
        {
            // TODO :)
        }


















        private void SendThankYouLetter(Customer customer)
        {
            //if (customer.EmailAddress.Length > MaxEmailLength)
            //{
            //    SendThankYouLetterInternal(customer.EmailAddress);
            //}
            //else
            //{
            //    Debug.Write("Email address too long!");
            //}
        }
        private static List<Customer> LoadCustomersFromDb()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            customers[5].Gender = Gender.Male;
            customers[5].CCType = "MasterCard";
            customers[5].Address.Country = "UK";
            customers[5].EmailAddress = null;

            return customers;
        }
    }
}
