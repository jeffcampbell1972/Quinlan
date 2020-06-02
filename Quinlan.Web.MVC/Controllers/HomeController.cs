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
        private IHomePageService _homePageService;
        public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
        {
            _logger = logger;
            _homePageService = homePageService;
        }

        public IActionResult Index()
        {
            var homeViewModel = _homePageService.Build();

            return View(homeViewModel);
        }
        public IActionResult Details()
        {
            var summaryViewModel = _homePageService.BuildSummary();

            return View(summaryViewModel);
        }
        public IActionResult Seed()
        {
            // seed code goes here

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
