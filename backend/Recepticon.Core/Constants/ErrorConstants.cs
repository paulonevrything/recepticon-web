using System;
namespace Recepticon.Core.Constants
{
    public static class ErrorConstants
    {
        public const string UNKNOWN_ERROR = "An unknown error has occured";
        public const string USER_NOT_FOUND = "User not found";
        public const string GUEST_NOT_FOUND = "Guest not found";
        public const string ROOM_NOT_FOUND = "Room not found";
        public const string ROOM_TYPE_NOT_FOUND = "Room type not found";
        public const string INVALID_CHECKIN_AND_CHECKOUT = "Checkout date cannot be before Checkin date";
    }
}
