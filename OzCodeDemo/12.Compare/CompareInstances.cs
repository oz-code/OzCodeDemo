using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using OzCodeDemo.DemoClasses;
using OzCodeDemo.DemoClasses.Customers;

namespace OzCodeDemo._12.Compare
{
    [Export(typeof(IOzCodeDemo))]
    [ExportMetadata("Demo", "CompareInstances")]
    public class CompareInstances : IOzCodeDemo
    {
        public void Start()
        {
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
                FirstName = "Jane",
                LastName = "Doe",
                Age = 42,
                Address = new Address
                {
                    Country = "FR",
                    City = "Paris",
                    StreetAddress = "5one la rue",
                    ZipCode = 11131719
                }
            });
            return phoneBook;
        }
    }
}
