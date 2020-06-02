using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;
using System;

namespace Quinlan.MVC.Controllers
{
    public class TeamsController : Controller
    {
        private static IDetailsService<TeamDetails> _teamDetailsService;
        private static IEditService<TeamEdit> _teamEditService;
        private static IFormService<TeamViewModel> _teamFormService;
        private static IIndexService<TeamIndex, TeamFilterOptionsViewModel> _teamIndexService;
       
        public TeamsController(IDetailsService<TeamDetails> teamDetailsService, IEditService<TeamEdit> teamEditService, IFormService<TeamViewModel> teamFormService, IIndexService<TeamIndex, TeamFilterOptionsViewModel> teamIndexService)
        {
            _teamDetailsService = teamDetailsService;
            _teamEditService = teamEditService;
            _teamFormService = teamFormService;
            _teamIndexService = teamIndexService;
        }
        public IActionResult Details(int id)
        {
            var vm = _teamDetailsService.Build(id, null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Details(int id, CardFilterOptionsViewModel filterOptions)
        {
            var vm = _teamDetailsService.Build(id, filterOptions);

            return View(vm);
        }
        public IActionResult Index()
        {
            var teamVM = _teamIndexService.Build(null);

            return View(teamVM);
        }
        [HttpPost]
        public IActionResult Index(TeamFilterOptionsViewModel teamFilterOptionsViewModel)
        {
            var teamVM = _teamIndexService.Build(teamFilterOptionsViewModel);

            return View(teamVM);
        }
        public IActionResult Edit(int id)
        {
            var teamVM = _teamEditService.Build(id);

            return View(teamVM);
        }
        [HttpPost]
        public IActionResult Edit(int id, TeamViewModel teamVM)
        {
            // id value is not hidden in form
            teamVM.Id = id;

            bool isValid = TryValidateModel(teamVM);

            if (isValid)
            {
                try
                {
                    _teamFormService.Save(id, teamVM);

                    return RedirectToAction("Details", new { id = id });
                }
                catch
                {
                    throw new Exception("Save failed.");
                }
            }
            var vm = _teamEditService.Build(id);

            return View(vm);
        }
    }
}