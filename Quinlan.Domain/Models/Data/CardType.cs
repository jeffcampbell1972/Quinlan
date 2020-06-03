
using System;

namespace Quinlan.Domain.Models
{
    public class CardType
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
