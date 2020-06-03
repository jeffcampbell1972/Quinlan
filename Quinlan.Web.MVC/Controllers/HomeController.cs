using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHomeService<Home> _indexService;
        private IHomeService<Summary> _detailsService;
        public HomeController(ILogger<HomeController> logger, IHomeService<Home> indexService, IHomeService<Summary> detailsService)
        {
            _logger = logger;
            _indexService = indexService;
            _detailsService = detailsService;
        }

        public IActionResult Index()
        {
            var homeViewModel = _indexService.Build();

            return View(homeViewModel);
        }
        public IActionResult Details()
        {
            var summaryViewModel = _detailsService.Build();

            return View(summaryViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
