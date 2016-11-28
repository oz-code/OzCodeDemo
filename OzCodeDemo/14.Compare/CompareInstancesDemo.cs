using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._14.Compare
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "CompareInstances")]
    public class CompareInstancesDemo : IOzCodeDemo
    {
        public void Start()
        {
            Debugger.Break();

            var phoneBook = LoadPhoneBook();

            using (var memoryStream = new MemoryStream())
            {
                phoneBook.Save(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var loadedPhoneBook = PhoneBook.CreateFromStream(memoryStream);

                Debug.Assert(phoneBook == loadedPhoneBook, "Something went wrong!!!");
            }
        }

        private static PhoneBook LoadPhoneBook()
        {
            var phoneBook = new PhoneBook();
            phoneBook.AddPerson(new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 44,
                Address = new Address
                {
                    Country = "US",
                    City = "New York",
                    State = "New York",
                    StreetAddress = "241812 fictive lane",
                    ZipCode = 12358
                }
            });

            phoneBook.AddPerson(new Person
            {
                FirstName = "Tom",
                LastName = "Jacobson",
                Age = 60,
                Address = new Address
                {
                    Country = "UK",
                    City = "London",
                    StreetAddress = "21 Baker St.",
                    ZipCode = 43245
                }
            });

            phoneBook.AddPerson(new Person
            {
                FirstName = "Sandra",
                LastName = "Jones",
                Age = 25,
                Address = new Address
                {
                    Country = "US",
                    City = "Paris",
                    State = "Texas",
                    StreetAddress = "1234 made up lane",
                    ZipCode = 11111
                }
            });

            phoneBook.AddPerson(new Person
            {
                FirstName = "Vanessa",
                LastName = "Biju",
                Age = 72,
                Address = new Address
                {
                    Country = "DE",
                    City = "Hamburg",
                    StreetAddress = "12244-24432423-432234",
                }
            });

            return phoneBook;
        }
    }
}
