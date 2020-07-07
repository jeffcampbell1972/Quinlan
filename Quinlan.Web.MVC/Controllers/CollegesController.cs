using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;
using System;

namespace Quinlan.MVC.Controllers
{
    public class CollegesController : Controller
    {
        private static IDetailsService<CollegeDetails> _collegeDetailsService;
        private static IEditService<CollegeEdit> _collegeEditService;
        private static IFormService<CollegeViewModel> _collegeFormService;
        public CollegesController(IDetailsService<CollegeDetails> collegeDetailsService, IEditService<CollegeEdit> collegeEditService, IFormService<CollegeViewModel> collegeFormService)
        {
            _collegeDetailsService = collegeDetailsService;
            _collegeEditService = collegeEditService;
            _collegeFormService = collegeFormService;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var vm = _collegeDetailsService.Build(id, null, User.IsInRole("Owner"));

            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(int id, CardFilterOptionsViewModel filterOptions)
        {
            var vm = _collegeDetailsService.Build(id, filterOptions, User.IsInRole("Owner"));

            return View(vm);
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Edit(int id)
        {
            var collegeVM = _collegeEditService.Build(id);

            return View(collegeVM);
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult Edit(int id, CollegeViewModel collegeVM)
        {
            // id value is not hidden in form
            collegeVM.Id = id;

            bool isValid = TryValidateModel(collegeVM);

            if (isValid)
            {
                try
                {
                    _collegeFormService.Save(id, collegeVM);

                    return RedirectToAction("Details", new { id = id });
                }
                catch
                {
                    throw new Exception("Save failed.");
                }
            }
            var vm = _collegeEditService.Build(id);

            return View(vm);
        }
    }
}