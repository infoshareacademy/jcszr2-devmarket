using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Services.Exercises;
using GymManagerWebApp.Models;

namespace GymManagerWebApp.Controllers
{
    public class ExercisesController : Controller
    {
        private IExercisesService _exerciseService;

        public ExercisesController(IExercisesService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        public async Task<IActionResult> Exercises()
        {
            var ExercisesModel = new Exercises();
            //var list = ExercisesModel.GetAllExercises();

            return View(ExercisesModel);
        }



        
    }
}
