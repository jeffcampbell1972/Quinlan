using System;

namespace Quinlan.Data
{
    public class InvalidDeleteException : Exception
    {
        public InvalidDeleteException(string message) : base(message)
        {
            
        }
    }
}
