using System;

namespace NewException.Entities.Exception
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) 
            : base(message)
        {
        }
    }
}
