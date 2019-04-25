using System;

namespace Server.Models.Exceptions
{
    /// <summary>
    /// A custom exception for when an incoming message fails validation.
    /// </summary>
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException(string message) : base(message)
        {

        }
    }
}
