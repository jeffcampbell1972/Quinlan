using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.Controllers
{
    [Authorize(Roles = "Nobody")]
    public class MagazinesController : Controller
    {
        private static IIndexService<MagazineIndex, MagazineFilterOptionsViewModel> _magazineIndexModelService;
        public MagazinesController(IIndexService<MagazineIndex, MagazineFilterOptionsViewModel> magazineIndexModelService)
        {
            _magazineIndexModelService = magazineIndexModelService;
        }
        public IActionResult Index()
        {
            var vm = _magazineIndexModelService.Build(null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(MagazineFilterOptionsViewModel filterOptions)
        {
            var vm = _magazineIndexModelService.Build(filterOptions);

            return View(vm);
        }
    }
}