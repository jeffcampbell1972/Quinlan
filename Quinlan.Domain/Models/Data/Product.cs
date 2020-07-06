
using System;
using System.Collections.Generic;

namespace Quinlan.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Player { get; set; }
        public string RC { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }
        public List<Card> Cards { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                Name ?? "",
                Price == -1 ? "[Not Priced]" : Price.ToString());
        }
    }
}
