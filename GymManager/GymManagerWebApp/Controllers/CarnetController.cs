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
            var carnetTypeNr = HttpContext.Request.Form[CARNET_FIELD]; //returns full ticket object
            var currentUserEmail = HttpContext.User.Identity.Name;
            await _carnetService.AddCarnetAsync(Int32.Parse(carnetTypeNr), currentUserEmail);

            return View("PurchaseConfirmation");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchasedCarnets()
        {
            string TimeCarnetCategoryName = new CarnetsOfferViewModel().TimeCarnetCategory;
            string QuantityCarnetCategoryName = new CarnetsOfferViewModel().QuantityCarnetCategory;
            var currentUserEmail = HttpContext.User.Identity.Name;
            PurchasedCarnetsViewModel model = new PurchasedCarnetsViewModel();

            model.TimeCarnets = await _carnetService.GetPurchasedCarnets(currentUserEmail, TimeCarnetCategoryName);
            model.QuantityCarnets = await  _carnetService.GetPurchasedCarnets(currentUserEmail, QuantityCarnetCategoryName);

            return View("PurchasedCarnets", model);
        }
    }
}
