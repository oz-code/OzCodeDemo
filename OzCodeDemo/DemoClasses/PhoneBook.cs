using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace OzCodeDemo.DemoClasses
{
    [Serializable]
    public class PhoneBook : IEquatable<PhoneBook>
    {
        public bool Equals(PhoneBook other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_book, other._book);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PhoneBook)obj);
        }

        public override int GetHashCode()
        {
            return (_book != null ? _book.GetHashCode() : 0);
        }

        public static bool operator ==(PhoneBook left, PhoneBook right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PhoneBook left, PhoneBook right)
        {
            return !Equals(left, right);
        }

        private List<Person> _book = new List<Person>();
        public void AddPerson(Person p)
        {
            _book.Add(p);
        }

        public void Save(Stream stream)
        {
            var bf = new BinaryFormatter();
            bf.Serialize(stream, _book.ToList());
        }

        public void Load(Stream stream)
        {
            var bf = new BinaryFormatter();
            var book = bf.Deserialize(stream) as IList<Person>;
            if (book == null)
                throw new IOException("Deserialization problems");
            _book.Clear();
            foreach (var person in book)
            {
                _book.Add(person);
            }
        }

        public static PhoneBook CreateFromStream(Stream stream)
        {
            var phoneBook = new PhoneBook();
            phoneBook.Load(stream);
            return phoneBook;
        }

        public List<Person> Persons
        {
            get { return _book; }
            set { _book = value; }
        }
    }

}
