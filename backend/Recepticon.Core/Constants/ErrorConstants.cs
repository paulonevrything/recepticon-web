using Microsoft.Extensions.Logging;
using Recepticon.Core.Exceptions;
using Recepticon.Core.Helpers;
using System;
using System.Collections.Generic;

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

        public static Exception ThrowException(Exception ex, ILogger logger)
        {
            logger.LogError(ex.Message);

            if ((ex.InnerException is KeyNotFoundException) || (ex.InnerException is InvalidCheckInAndCheckOutException)
                 || (ex.InnerException is OccupiedRoomException) || (ex.InnerException is AlreadyExistException))
            {
                return ex;
            }

            return new CustomException(UNKNOWN_ERROR);
        }
    }
}
