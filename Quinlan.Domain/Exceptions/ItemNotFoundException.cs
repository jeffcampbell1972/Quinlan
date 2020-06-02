using System;

namespace Quinlan.Domain
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message)
        {
            
        }
    }
}
