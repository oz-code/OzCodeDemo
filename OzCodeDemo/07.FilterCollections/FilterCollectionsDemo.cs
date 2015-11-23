using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._07.FilterCollections
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "FilterCollections")]
    public class FilterCollectionsDemo : IOzCodeDemo
    {
        public void Start()
        {
            try
            {
                SendGiftsToCustomers();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception!");
            }
        }

        private static void SendGiftsToCustomers()
        {
            foreach (var customer in GetPrizeWinners(prizesToGive: 10))
            {
                SendGift(customer);
            }
        }

        private static int SendGift(Customer customer)
        {
            int retailerGiftPrice = IsElgibileForDiscount(SupplierId) ? GetDiscountPrice() : GetRegularPrice();

            int shippingCost;
            if (int.TryParse(GetShippingCostFromConfig(), out shippingCost))
            {
                retailerGiftPrice += shippingCost;
            }

            AddVAT(ref retailerGiftPrice);

            return retailerGiftPrice + GetExtraFreebiesCost(customer);
        }



        private static List<Customer> GetPrizeWinners(int prizesToGive)
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            var prizeWinners = customers.Where(IsEligibleForPrize)
                                        .Where(c => c.Age < 62)
                                        .OrderBy(c => c.Age)
                                        .Take(prizesToGive);


            if (prizeWinners.Count() != prizesToGive)
            {
                throw new InvalidOperationException("There were not enough prize winners!");
            }

            return prizeWinners.ToList();
        }

        private static void AddVAT(ref int currentGiftPrice)
        {
            currentGiftPrice = Convert.ToInt32(currentGiftPrice * 1.18);
        }

        private static bool IsEligibleForPrize(Customer customer)
        {
            return customer.Gender == Gender.Female;
        }

        private static int GetDiscountPrice()
        {
            return 250;
        }

        private static int GetRegularPrice()
        {
            return 300;
        }

        private static bool IsElgibileForDiscount(int supplierId)
        {
            return false;
        }

        private static string GetShippingCostFromConfig()
        {
            return "21";
        }

        private static int GetExtraFreebiesCost(Customer customer)
        {
            return 52;
        }

        public static int SupplierId { get { return 23652; } }
    }
}
