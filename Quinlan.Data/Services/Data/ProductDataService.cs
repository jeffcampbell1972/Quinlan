using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
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
            var productData = _qDb.Products.Include(x => x.Collectibles).SingleOrDefault(x => x.Id == id);

            if (productData == null)
            {
                throw new InvalidIdException("Id not found in Products.");
            }

            return productData;
        }
        public void Insert(Product product)
        {
            // not sure whether this will affect the Collectibles which are related to the Product.
            // currently, the domain drives the logic which updates each Collectible in the Product.
            // if hydrated Collectibles list is provided, it might handle those updates without
            // extra code.

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
