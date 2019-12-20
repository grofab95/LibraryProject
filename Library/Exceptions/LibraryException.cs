using System;
using System.Globalization;

namespace Library.Exceptions
{
    public class LibraryException : Exception
    {
        public LibraryException() : base() { }

        public LibraryException(string exceptionMessage) : base(exceptionMessage) { }

        public LibraryException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
