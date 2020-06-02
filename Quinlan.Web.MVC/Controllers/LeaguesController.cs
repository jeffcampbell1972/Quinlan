using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.MVC.Controllers
{
    public class LeaguesController : Controller
    {
        private static IDetailsService<LeagueDetails> _leagueDetailsService;
        public LeaguesController(IDetailsService<LeagueDetails> leagueDetailsService)
        {
            _leagueDetailsService = leagueDetailsService;
        }
        public IActionResult Details(int id)
        {
            var vm = _leagueDetailsService.Build(id, null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Details(int id, CardFilterOptionsViewModel filterOptions)
        {
            var vm = _leagueDetailsService.Build(id, filterOptions);

            return View(vm);
        }
    }
}