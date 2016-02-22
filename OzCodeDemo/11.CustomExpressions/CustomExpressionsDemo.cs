using OzCodeDemo.DemoClasses.Customers;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;

namespace OzCodeDemo._11.CustomExpressions
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "CustomExpressions")]
    public class CustomExpressionsDemo : IOzCodeDemo
    {
        public void Start()
        {
            var customers = CustomersRepository.LoadCustomersFromDb();

            DateTime today = new DateTime(2015, 02, 20);

            Debugger.Break();

            var customersSortedByBirthday =
                from customer in customers
                let daysTillBirthday = DaysTillBirthday(customer, today)
                orderby daysTillBirthday
                select customer;

            var needToWaitLongest = customersSortedByBirthday.Last();
            Debug.Assert(needToWaitLongest.FirstName != "Ben");
        }



        public int DaysTillBirthday(Customer customer, DateTime today)
        {
            try
            {
                var birthday = customer.Birthday;

                DateTime next = new DateTime(today.Year, birthday.Month, birthday.Day);

                if (next < today)
                    next = next.AddYears(1);

                return (next - today).Days;
            }
            catch (Exception)
            {
                return int.MaxValue;
            }
        }
    }
}
