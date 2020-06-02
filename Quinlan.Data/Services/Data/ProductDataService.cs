using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class ProductDataService : IDataService<Product>
    {
        QdbContext _qDb;
        public ProductDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Product> Select()
        {
            var productsData = _qDb.Products
               .ToList();

            return productsData;
        }
        public Product Select(int id)
        {
            var productData = _qDb.Products.SingleOrDefault(x => x.Id == id);

            if (productData == null)
            {
                throw new InvalidIdException("Id not found in Products.");
            }

            return productData;
        }
        public void Insert(Product product)
        {
            _qDb.Products.Add(product);
            _qDb.SaveChanges();
        }
        public void Update(int id, Product product)
        {
            var productData = _qDb.Products.SingleOrDefault(x => x.Id == id);

            if (productData == null)
            {
                throw new InvalidIdException("Id not found in Products.");
            }
            productData = product;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var productData = _qDb.Products.SingleOrDefault(x => x.Id == id);

            if (productData == null)
            {
                throw new InvalidIdException("Id not found in Products.");
            }
            _qDb.Products.Remove(productData);
            _qDb.SaveChanges();
        }
    }
}
