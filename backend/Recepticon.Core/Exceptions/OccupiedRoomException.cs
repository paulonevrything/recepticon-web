using System;
using System.Globalization;

namespace Recepticon.Core.Exceptions
{
    public class OccupiedRoomException : Exception
    {
        public OccupiedRoomException() : base() { }

        public OccupiedRoomException(string message) : base(message) { }

        public OccupiedRoomException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
