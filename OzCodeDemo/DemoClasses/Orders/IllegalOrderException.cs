using System;
using System.Runtime.Serialization;

namespace OzCodeDemo.DemoClasses.Orders
{
    [Serializable]
    public class IllegalOrderException : Exception
    {
        public IllegalOrderException()
        {
        }

        public IllegalOrderException(string message) : base(message)
        {
        }

        public IllegalOrderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected IllegalOrderException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
