using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Exceptions
{
    public class EmailAlreadyTaken : LibraryException
    {
        public EmailAlreadyTaken(string email) :
            base($"Email: {email} już istnieje")
        { }
    }
}
