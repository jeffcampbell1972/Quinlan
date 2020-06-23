using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Quinlan.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductStatusId { get; set; }
        public decimal? Price { get; set; }

        public Owner Owner { get; set; }
        public ProductType ProductType { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public List<Collectible> Collectibles { get; set; }
    }
}
