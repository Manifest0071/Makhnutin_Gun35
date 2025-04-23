using System;

namespace SocialCasino.Exceptions
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string message) : base(message) { }
    }
}