using System;
using System.Globalization;

namespace Recepticon.Core.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException() : base() { }

        public AlreadyExistException(string message) : base(message) { }

        public AlreadyExistException(string message, Exception inner) : base(message, inner) { }
        
        public AlreadyExistException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
