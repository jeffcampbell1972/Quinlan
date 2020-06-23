using System;
using System.Collections.Generic;
using System.Linq;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class ProductService : ICrudService<Product>
    {
        IDataService<Quinlan.Data.Models.Product> _productDataService;
        public ProductService(IDataService<Quinlan.Data.Models.Product> productDataService)
        {
            _productDataService = productDataService;
        }

        public List<Product> Get()
        {
            var productsData = _productDataService.Select();

            var products = productsData
                .Select(x => new Product
                {
                    Id = x.Id,
                    Identifier = x.Identifier ,
                    Name = x.Name ,
                    Price = x.Price
                })
                .ToList();

            return products;
        }
        public Product Get(int id)
        {
            var productData = _productDataService.Select(id);

            if (productData == null)
            {
                throw new ItemNotFoundException("Product not found.  Invalid id provided.");
            }

            var product = new Product
            { 
                Id = productData.Id, 
                Identifier = productData.Identifier ,
                Name = productData.Name ,
                Price = productData.Price 
            };

            return product;
        }
        public void Post(Product product)
        {
            var productData = new Quinlan.Data.Models.Product
            {
                Identifier = product.Name ,
                Name = product.Name ,
                Price = product.Price 
            };

            _productDataService.Insert(productData);
        }
        public void Put(int id, Product product)
        {
            var productData = _productDataService.Select(id);

            productData.Name = product.Name;
            productData.Price = product.Price;

            _productDataService.Update(id, productData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
