using GymManagerWebApp.Models;
using GymManagerWebApp.Services.CoachService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Controllers
{
    public class CoachController : Controller
    {
        private ICoachService _coachService;
        public IActionResult Index()
        {
            return View();
        }

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddNewCoach()
        {
            var coach = new AddCoachViewModel();
            return View("AddCoach", coach);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> ConfirmAddingNewCoach(AddCoachViewModel coach)
        {
            if (ModelState.IsValid)
            {
                await _coachService.AddCoachAsync(coach.CoachName, coach.CoachSurName);
                return View("AddCoachConfirmation");
            } else
            {
                return View();
            }
        }
    }
}