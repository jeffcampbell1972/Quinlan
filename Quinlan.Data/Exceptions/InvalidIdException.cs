using System;

namespace Quinlan.Data
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message)
        {
            
        }
    }
}
