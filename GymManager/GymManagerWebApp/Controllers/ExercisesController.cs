using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Services.Exercises;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using GymManagerWebApp.Services.CoachService;
using GymManagerWebApp.Models.Exercises;

namespace GymManagerWebApp.Controllers
{
    public class ExercisesController : Controller
    {
        private IExercisesService _exerciseService;
        private ICoachService _coachService;

        public ExercisesController(IExercisesService exerciseService, ICoachService coachService)
        {
            _exerciseService = exerciseService;
            _coachService = coachService;
        }
        [HttpGet]
        public async Task<IActionResult> Exercises()
        {
            var ExercisesModel = new Exercise();
            var list = await _exerciseService.GetAllExercises();
            return View(list);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> AddNewExercise()
        {
            var exercise = new ExerciseViewModel();
            exercise.CoachId = 0;
            exercise.CoachList = await _coachService.GetAllCoaches();
            return View("AddExercise", exercise);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> ConfirmAddingNewExercise(ExerciseViewModel exercise)
        {
            if (ModelState.IsValid)
            {
                //await _coachService.AddCoachAsync(exercise.CoachName, exercise.CoachSurName);
                await _coachService.AddExerciseAsync();
                return View("AddCoachConfirmation");
            }
            else
            {
                return View();

            }
        }
    }
}
