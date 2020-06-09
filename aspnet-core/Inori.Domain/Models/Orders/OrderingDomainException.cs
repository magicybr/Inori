using System;
using System.Runtime.Serialization;

namespace Inori.Domain.Models.Orders
{
    public class OrderingDomainException : Exception
    {
        public OrderingDomainException()
        {
            
        }

        public OrderingDomainException(string message) : base(message)
        {
        }

        public OrderingDomainException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}