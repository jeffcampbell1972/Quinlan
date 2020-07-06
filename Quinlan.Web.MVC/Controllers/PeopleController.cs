using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;
using System;

namespace Quinlan.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private static IDetailsService<PersonDetails> _personDetailsService;
        private static IEditService<PersonEdit> _personEditService;
        private static IFormService<PersonViewModel> _personFormService;
        private static IIndexService<PersonIndex,PersonFilterOptionsViewModel> _personIndexService;

        public PeopleController(IDetailsService<PersonDetails> personDetailsService , IEditService<PersonEdit> personEditService, IFormService<PersonViewModel> personFormService, IIndexService<PersonIndex, PersonFilterOptionsViewModel> personIndexService )
        {
            _personDetailsService = personDetailsService;
            _personEditService = personEditService;
            _personFormService = personFormService;
            _personIndexService = personIndexService;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var vm = _personDetailsService.Build(id, null);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Details(int id, CardFilterOptionsViewModel filterOptions)
        {
            var vm = _personDetailsService.Build(id, filterOptions);

            return View(vm);
        }
        [Authorize]
        public IActionResult Index()
        {
            var peopleVM = _personIndexService.Build(null);

            return View(peopleVM);
        }
        [HttpPost]
        public IActionResult Index(PersonFilterOptionsViewModel personFilterOptionsViewModel)
        {
            var peopleVM = _personIndexService.Build(personFilterOptionsViewModel);

            return View(peopleVM);
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Edit(int id)
        {
            var peopleVM = _personEditService.Build(id);

            return View(peopleVM);
        }
        [HttpPost]
        public IActionResult Edit(int id, PersonViewModel personVM)
        {
            // id value is not hidden in form
            personVM.Id = id;

            bool isValid = TryValidateModel(personVM);

            if (isValid)
            {
                try
                {
                    _personFormService.Save(id, personVM);

                    return RedirectToAction("Details",  new { id = id } );
                }
                catch
                {
                    throw new Exception("Save failed.");
                }
            }
            var vm = _personEditService.Build(id);

            return View(vm);
        }
    }
}