﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Recepticon.Core.Helpers 
{ 

    public class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }

        public CustomException(string message, Exception inner) : base(message, inner) { }

        public CustomException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}