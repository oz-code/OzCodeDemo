using System;

namespace OzCodeDemo.DemoClasses.Customers
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Customer
    {
        public Customer Parent { get; set; }

        public int Age
        {
            get
            {
                return (int)(DateTime.Now - Birthday).TotalDays % 365;
            }
        }

        public int Id { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string MothersMaiden { get; set; }
        public DateTime Birthday { get; set; }
        public string CCType { get; set; }
        public string CCNumber { get; set; }
        public string CVV2 { get; set; }
        public string CCExpires { get; set; }
        public string NationalID { get; set; }
        public string UPS { get; set; }
        public string Occupation { get; set; }
        public string Domain { get; set; }
        public string BloodType { get; set; }
        public string Pounds { get; set; }
        public string Kilograms { get; set; }
        public string FeetInches { get; set; }
        public string Centimeters { get; set; }

        public string CaseFileID
        {
            get { return "JOHN_BRIGGS_8515"; }

        }


        private int _pendingInvoiceID;



        public int PendingInvoiceID
        {
            get { return _pendingInvoiceID; }
            set { _pendingInvoiceID = value; }
        }

        public Address Address { get; set; }

        public double GetYearlyEarnings(int year)
        {
            return year * 2;
        }
    }
}
