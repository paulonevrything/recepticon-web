using System;
using System.Globalization;

namespace Recepticon.Core.Exceptions
{
    public class InvalidCheckInAndCheckOutException : Exception
    {

        public InvalidCheckInAndCheckOutException() : base() { }

        public InvalidCheckInAndCheckOutException(string message) : base(message) { }

        public InvalidCheckInAndCheckOutException(string message, Exception inner) : base(message, inner) { }

        public InvalidCheckInAndCheckOutException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
