using System.Collections.Generic;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using Quinlan.Data.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class HomeIndexService : IHomeService<Home>
    {
        ICrudService<Product> _productService;
        public HomeIndexService(ICrudService<Product> productService)
        {
            _productService = productService;
        }
        public Home Build()
        {
            var products = _productService.Get();

            var vm = new Home
            {
                WelcomeMessage = "Check out the great cards he's got in there!",
                Title = "Home" ,
                Header = "Welcome to Q's Closet",
                IsSeeded = true ,
                SingleCardProducts = GetProducts(products, ProductTypeCodeService.Single.Id),
                CardLotProducts = GetProducts(products, ProductTypeCodeService.Lot.Id),
                CollectionProducts = GetProducts(products, ProductTypeCodeService.Collection.Id),
                GolfId = SportCodeService.Golf.Id
            };

            return vm;
        }
        private List<ProductListItemViewModel> GetProducts(List<Product> products, int ProductTypeId)
        {
            var productsList = products
                .Where(x => x.ProductType.Id == ProductTypeId)
                .Select(x => new ProductListItemViewModel
                {
                    Id = x.Id ,
                    Description = x.Name ,
                    Price = string.Format("{0:c0}", x.Price)
                })
                .ToList();

            return productsList;
        }
    }
}
