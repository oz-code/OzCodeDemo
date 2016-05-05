using System;
using System.Diagnostics;

namespace OzCodeDemo.DemoClasses.Customers
{
    [Serializable]
    public class Address
    {
        [NonSerialized, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _city;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _state;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _zipCode;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _country;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _streetAddress;

        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
    }
}