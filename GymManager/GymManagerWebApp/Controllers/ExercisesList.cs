using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class ExercisesList : Controller
    {
        public async Task<IActionResult> Exercises()
        {
            var ExercisesModel = new Exercises();
            await ExercisesModel.Init();

            return View(ExercisesModel);
        }
    }
}
