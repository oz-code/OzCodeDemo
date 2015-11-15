using System;
using System.Runtime.Serialization;

namespace OzCodeDemo.DemoClasses.Orders
{
    [Serializable]
    public class OrderProcessingException : Exception
    {
        public OrderProcessingException()
        {
        }

        public OrderProcessingException(string message) : base(message)
        {
        }

        public OrderProcessingException(string message, Exception inner) : base(message, inner)
        {
        }

        protected OrderProcessingException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}