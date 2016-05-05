using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using OzCodeDemo.DemoClasses.Customers;
using OzCodeDemo.DemoClasses.Extensions;

namespace OzCodeDemo.DemoClasses
{
    [Serializable]
    public class Person : IEquatable<Person>
    {
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NonSerialized, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value < 0 || value > 130)
                    throw new InvalidDataException("Age must be between 0 to 150");

                _age = value;
            }
        }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _age == other._age && Equals(Address, other.Address) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _age;
                hashCode = (hashCode * 397) ^ (Address != null ? Address.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                return hashCode;
            }
        }
/*
        [XmlIgnore]
        public string RawInfo
        {
            get { return this.SerializeObject(); }
        }*/
    }
}
