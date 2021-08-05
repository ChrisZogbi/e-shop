using System;

namespace eShop.Api.Domain.Exceptions
{
    public class eShopDomainException : Exception
    {
        public eShopDomainException()
        { }

        public eShopDomainException(string message)
            : base(message)
        { }

        public eShopDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
