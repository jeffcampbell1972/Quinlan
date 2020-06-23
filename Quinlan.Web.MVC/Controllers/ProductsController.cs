using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<CardsController> _logger;

        private static IIndexService<ProductIndex,ProductFilterOptionsViewModel> _productIndexService;
        private static IDetailsService<ProductDetails> _productDetailsService;
        public ProductsController(ILogger<CardsController> logger, IIndexService<ProductIndex,ProductFilterOptionsViewModel> productIndexService, IDetailsService<ProductDetails> productDetailsService)
        {
            _logger = logger;
            _productIndexService = productIndexService;
            _productDetailsService = productDetailsService;
        }
        public IActionResult Index()
        {
            try
            {
                var vm = _productIndexService.Build(null);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                throw ex;
            }
        }
        public IActionResult Details(int id)
        {
            var vm = _productDetailsService.Build(id, null);

            return View(vm);
        }
    }
}