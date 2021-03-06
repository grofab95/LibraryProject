﻿namespace Library.Exceptions
{
    public class AuthorExist : LibraryException
    {
        public AuthorExist(string name) : base($"Autor: {name} już istnieje.")
        {
        }

        public AuthorExist() : base("Autor już istnieje.")
        { 
        }
    }
}
