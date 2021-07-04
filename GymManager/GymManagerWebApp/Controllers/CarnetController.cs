using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.CarnetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymManagerWebApp.Controllers
{
    public class CarnetController : Controller
    {
        private  ICarnetService _carnetService;
        private string _timeCarnetCategoryName = new CarnetsOfferViewModel().TimeCarnetCategory;
        private string _quantityCarnetCategoryName = new CarnetsOfferViewModel().QuantityCarnetCategory;
        private readonly ILogger<CarnetController> _logger;
        private readonly IUserService _userService;

        public CarnetController(ICarnetService carnetService, ILogger<CarnetController> logger, IUserService userService)
        {
            _carnetService = carnetService;
            _logger = logger;
            _userService = userService;
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
            var currentUser = _userService.GetUserByEmailAsync(currentUserEmail);
            var userId = currentUser.Id;
            var carnet = _carnetService.GetCarnetByNr(carnetTypeNr);

            await _carnetService.AddCarnetAsync(carnetTypeNr, currentUserEmail);
            _logger.LogInformation($"User with id:{userId} | Purchased ticket: {carnet.Name}");
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
            var user = _userService.GetUserByEmailAsync(userEmail);
            var carnetName = _carnetService.GetPurchasedCarnetNameById(carnetId);
            var isAnyActive = await _carnetService.IsAnyActive(userEmail);

            if(isAnyActive)
            {
                _logger.LogDebug($"User {user.Id}, failed to activate time carnet, 1 carnet is already activated");
                ModelState.AddModelError("","Posiadasz już jeden aktywny bilet czasowy, nie można posiadać 2 aktywnych karnetów jednocześnie");
                model.TimeCarnets = await _carnetService.GetPurchasedCarnets(userEmail, _timeCarnetCategoryName);
                model.QuantityCarnets = await _carnetService.GetPurchasedCarnets(userEmail, _quantityCarnetCategoryName);
                return View(model);
            }

            await _carnetService.ActivateCarnet(carnetId);
            _logger.LogInformation($"User of id: {user.Id} | activated carnet: {carnetName}");
            return View("ActivateCarnetConfirmation");
        }


        [Authorize(Roles ="Administrator")]
        [HttpGet]
        public async Task<IActionResult> AllPurchasedCarnets(PurchasedCarnetsViewModel model)
        {
            model.TimeCarnets = await _carnetService.GetPurchasedCarnets(_timeCarnetCategoryName);
            model.QuantityCarnets = await _carnetService.GetPurchasedCarnets(_quantityCarnetCategoryName);

            return View("PurchasedCarnets", model);
        }

    }
}
