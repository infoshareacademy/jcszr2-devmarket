using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class TicketsController : Controller
    {
        [Authorize]
        public IActionResult BuyCarnet()
        {
            var TicketsModel = new BuyCarnet();
            return View(TicketsModel);
        }

        [HttpPost]
        public IActionResult BuyCarnet(BuyCarnet Carnet)
        {
            const string CARNET_FIELD = "CarnetType";
            var carnetTypeId = HttpContext.Request.Form[CARNET_FIELD];

            return Redirect("/");
        }
    }
}
