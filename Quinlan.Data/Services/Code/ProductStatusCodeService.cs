using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class ProductStatusCodeService
    {
        private static List<ProductStatus> values;
        public static List<ProductStatus> Select()
        {
            if (values == null)
            {
                values = new List<ProductStatus>() {
                    Pending ,
                    ForSale ,
                    Sold
                };
            }
            return values;
        }
        public static ProductStatus Select(int id)
        {
            if (values == null)
            {
                values = new List<ProductStatus>() {
                    Pending ,
                    ForSale ,
                    Sold
                };
            }
            return values.Single(x => x.Id == id);
        }
        static private ProductStatus pending;
        static private ProductStatus forsale;
        static private ProductStatus sold;

        static public ProductStatus Pending { get { return pending ?? (pending = new ProductStatus { Id = 1, Name = "Pending" }); } }
        static public ProductStatus ForSale { get { return forsale ?? (forsale = new ProductStatus { Id = 2, Name = "For Sale" }); } }
        static public ProductStatus Sold { get { return sold ?? (sold = new ProductStatus { Id = 3, Name = "Sold" }); } }
    }
}
