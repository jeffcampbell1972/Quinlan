using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;
using System.Collections.Generic;

namespace Quinlan.MVC.Services
{
    public class ProductIndexService : IIndexService<ProductIndex, ProductFilterOptionsViewModel>
    {
        ICrudService<Product> _productService;

        public ProductIndexService(ICrudService<Product> productService)
        {
            _productService = productService;
        }
        public ProductIndex Build(ProductFilterOptionsViewModel filterOptionsViewModel)
        {
            var products = _productService.Get();

            var productIndex = new ProductIndex
            {
                Products = products.Select(x => new ProductListItemViewModel
                {
                    Id = x.Id,
                    Description = x.Name
                })
                .ToList()
            };

            return productIndex;
        }
    }
}
