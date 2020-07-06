using System;

namespace Quinlan.Domain
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {
            
        }
    }
}
