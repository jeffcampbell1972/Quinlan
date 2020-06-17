
using System;
using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public List<Card> Cards { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                Name ?? "",
                Price == null ? "[Not Priced]" : Price.ToString());
        }
    }
}
