using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.Controllers
{
    public class FigurinesController : Controller
    {
        private static IIndexService<FigurineIndex, FigurineFilterOptionsViewModel> _figurineIndexModelService;
        public FigurinesController(IIndexService<FigurineIndex, FigurineFilterOptionsViewModel> figurineIndexModelService)
        {
            _figurineIndexModelService = figurineIndexModelService;
        }
        public IActionResult Index()
        {
            var vm = _figurineIndexModelService.Build(null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(FigurineFilterOptionsViewModel filterOptions)
        {
            var vm = _figurineIndexModelService.Build(filterOptions);

            return View(vm);
        }
    }
}