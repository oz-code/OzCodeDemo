using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._09.MagicGlance
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "MagicGlance")]
    public class MagicGlanceDemo : IOzCodeDemo
    {
        public void Start()
        {
            var customers = CustomersRepository.LoadCustomersFromDb().Take(10);

            var expenses = customers.Sum(customer => CalculateExpenses(customer));

            MessageBox.Show("Total cost for customers: " + expenses);
        }

        private static double CalculateExpenses(Customer customer)
        {
            Debugger.Break();

            int retailerGiftPrice = IsElgibileForDiscount(customer) ? GetDiscountPrice() : GetRegularPrice();

            int shippingCost;
            if (int.TryParse(GetShippingCostFromConfig(), out shippingCost))
            {
                retailerGiftPrice += shippingCost;
            }

            AddVAT(ref retailerGiftPrice);

            return retailerGiftPrice + GetExtraFreebiesCost(customer);
        }

        private static string GetShippingCostFromConfig()
        {
            return "404";
        }

        private static double GetExtraFreebiesCost(Customer customer)
        {
            return customer.GetYearlyEarnings(100) + 52;
        }

        private static int GetRegularPrice()
        {
            return 512;
        }

        private static int GetDiscountPrice()
        {
            return 256;
        }

        private static bool IsElgibileForDiscount(Customer customer)
        {
            return customer.Birthday.Month < 6;
        }

        private static void AddVAT(ref int currentGiftPrice)
        {
            currentGiftPrice = Convert.ToInt32(currentGiftPrice * 1.18);
        }
    }
}
