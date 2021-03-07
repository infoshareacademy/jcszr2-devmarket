using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class AvailableExercisesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}