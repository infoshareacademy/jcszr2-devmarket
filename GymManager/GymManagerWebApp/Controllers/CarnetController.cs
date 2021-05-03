using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services.CarnetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class CarnetController : Controller
    {
        private  ICarnetService _carnetService;
        private string _timeCarnetCategoryName = new CarnetsOfferViewModel().TimeCarnetCategory;
        private string _quantityCarnetCategoryName = new CarnetsOfferViewModel().QuantityCarnetCategory;

        public CarnetController(ICarnetService userService)
        {
            _carnetService = userService;
        }

        [HttpGet]
        public IActionResult BuyCarnet(CarnetsOfferViewModel carnet)
        {
            return View(carnet);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuyCarnet()
        {
            const string CARNET_FIELD = "CarnetType";
            var carnetTypeNr = Int32.Parse(HttpContext.Request.Form[CARNET_FIELD]);
            var currentUserEmail = HttpContext.User.Identity.Name;
            await _carnetService.AddCarnetAsync(carnetTypeNr, currentUserEmail);

            return View("PurchaseConfirmation");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchasedCarnets(PurchasedCarnetsViewModel model)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;
            model.TimeCarnets = await _carnetService.GetPurchasedCarnets(currentUserEmail, _timeCarnetCategoryName);
            model.QuantityCarnets = await  _carnetService.GetPurchasedCarnets(currentUserEmail, _quantityCarnetCategoryName);

            return View("PurchasedCarnets", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchasedCarnets(PurchasedCarnetsViewModel model, int carnetId) //Activates carnet
        {
            var userEmail = HttpContext.User.Identity.Name;
            var isAnyActive = await _carnetService.IsAnyActive(userEmail);

            if(isAnyActive)
            {
                ModelState.AddModelError("","Posiadasz już jeden aktywny bilet czasowy, nie można posiadać 2 aktywnych karnetów jednocześnie");
                model.TimeCarnets = await _carnetService.GetPurchasedCarnets(userEmail, _timeCarnetCategoryName);
                model.QuantityCarnets = await _carnetService.GetPurchasedCarnets(userEmail, _quantityCarnetCategoryName);
                return View(model);
            }

            await _carnetService.ActivateCarnet(carnetId);
            return View("ActivateCarnetConfirmation");
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> AllPurchasedCarnets(PurchasedCarnetsViewModel model)
        {
            model.TimeCarnets = await _carnetService.GetPurchasedCarnets(_timeCarnetCategoryName);
            model.QuantityCarnets = await _carnetService.GetPurchasedCarnets(_quantityCarnetCategoryName);

            return View("PurchasedCarnets", model);
        }

    }
}
