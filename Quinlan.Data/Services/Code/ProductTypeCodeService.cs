using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class ProductTypeCodeService
    {
        private static List<ProductType> values;
        public static List<ProductType> Select()
        {
            if (values == null)
            {
                values = new List<ProductType>() {
                    Single ,
                    Lot ,
                    Collection
                };
            }
            return values;
        }
        public static ProductType Select(int id)
        {
            if (values == null)
            {
                values = new List<ProductType>() {
                    Single ,
                    Lot ,
                    Collection
                };
            }
            return values.Single(x => x.Id == id);
        }
        static private ProductType single;
        static private ProductType lot;
        static private ProductType collection;

        static public ProductType Single { get { return single ?? (single = new ProductType { Id = 1, Name = "Single" }); } }
        static public ProductType Lot { get { return lot ?? (lot = new ProductType { Id = 2, Name = "Lot" }); } }
        static public ProductType Collection { get { return collection ?? (collection = new ProductType { Id = 3, Name = "Collection" }); } }
    }
}
