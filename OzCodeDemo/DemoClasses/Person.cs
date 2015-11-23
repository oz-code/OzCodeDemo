using System;
using System.IO;

namespace OzCodeDemo.DemoClasses
{
    [Serializable]
    public class Person : IEquatable<Person>
    {
        [NonSerialized]
        private int _age;
        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && Age == other.Age;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Age;
                return hashCode;
            }
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !Equals(left, right);
        }

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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("Age: {0}, FirstName: {1}, LastName: {2}", Age, FirstName, LastName);
        }
    }

}
