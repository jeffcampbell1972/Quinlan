using System.Collections.Generic;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
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
            var vm = new Home
            {
                WelcomeMessage = "He's got a lot of good cards in there!",
                Title = "Home" ,
                Header = "Welcome to Q's Closet",
                IsSeeded = true ,
                FeaturedProducts = GetProducts() ,
                GolfId = 5
            };

            return vm;
        }
        private List<ProductListItemViewModel> GetProducts()
        {
            var products = _productService.Get();

            var productsList = products.Select(x => new ProductListItemViewModel
            {
                Id = x.Id ,
                Name = x.Name
            })
            .ToList();

            return productsList;
        }
    }
}
