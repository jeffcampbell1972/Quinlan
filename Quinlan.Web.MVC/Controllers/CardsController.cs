using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Quinlan.MVC.Models;
using Quinlan.MVC.Services;

namespace Quinlan.Controllers
{
    public class CardsController : Controller
    {
        private readonly ILogger<CardsController> _logger;

        private static IViewService<CardView> _cardViewService;
        private static IEditService<CardEdit> _cardEditService;
        private static IFormService<CardViewModel> _cardFormService;
        public CardsController(ILogger<CardsController> logger, IViewService<CardView> cardViewService, IEditService<CardEdit> cardEditService, IFormService<CardViewModel> cardFormService)
        {
            _logger = logger;
            _cardViewService = cardViewService;
            _cardEditService = cardEditService;
            _cardFormService = cardFormService;
        }

        public IActionResult View(int id)
        {
            try
            {
                var vm = _cardViewService.Build(id);

                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                throw ex;
            }
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Edit(int id)
        {
            var cardVM = _cardEditService.Build(id);

            return View(cardVM);
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult Edit(int id, CardViewModel cardVM)
        {
            // id value is not hidden in form
            cardVM.Id = id;

            bool isValid = TryValidateModel(cardVM);

            if (isValid)
            {
                try
                {
                    _cardFormService.Save(id, cardVM);

                    return RedirectToAction("Details", new { id = id });
                }
                catch
                {
                    throw new Exception("Save failed.");
                }
            }
            var vm = _cardEditService.Build(id);

            return View(vm);
        }
    }
}