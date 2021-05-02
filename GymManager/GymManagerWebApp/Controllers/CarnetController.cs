﻿using System;
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
        private string TimeCarnetCategoryName = new CarnetsOfferViewModel().TimeCarnetCategory;
        private string QuantityCarnetCategoryName = new CarnetsOfferViewModel().QuantityCarnetCategory;

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
            model.TimeCarnets = await _carnetService.GetPurchasedCarnets(currentUserEmail, TimeCarnetCategoryName);
            model.QuantityCarnets = await  _carnetService.GetPurchasedCarnets(currentUserEmail, QuantityCarnetCategoryName);

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
                model.TimeCarnets = await _carnetService.GetPurchasedCarnets(userEmail, TimeCarnetCategoryName);
                model.QuantityCarnets = await _carnetService.GetPurchasedCarnets(userEmail, QuantityCarnetCategoryName);
                return View(model);
            }

            await _carnetService.ActivateCarnet(carnetId);
            return View("ActivateCarnetConfirmation");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ActiveCarnets()
        {

            string TimeCarnetCategoryName = new CarnetsOfferViewModel().TimeCarnetCategory;
            string QuantityCarnetCategoryName = new CarnetsOfferViewModel().QuantityCarnetCategory;
            var currentUserEmail = HttpContext.User.Identity.Name;
            var model = new PurchasedCarnetsViewModel();

            model.TimeCarnets = await _carnetService.GetActivatedCarnets(currentUserEmail, TimeCarnetCategoryName);
            model.QuantityCarnets = await _carnetService.GetActivatedCarnets(currentUserEmail, QuantityCarnetCategoryName);

            return View("ActiveCarnets", model);
        }
    }
}
