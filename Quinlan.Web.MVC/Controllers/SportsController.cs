using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.MVC.Controllers
{
    public class SportsController : Controller
    {
        private static IDetailsService<SportDetails> _sportDetailsService;
        public SportsController(IDetailsService<SportDetails> sportDetailsService)
        {
            _sportDetailsService = sportDetailsService;
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Details(int id)
        {
            var vm = _sportDetailsService.Build(id, null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Details(int id, CardFilterOptionsViewModel filterOptions)
        {
            var vm = _sportDetailsService.Build(id, filterOptions);

            return View(vm);
        }
    }
}