using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class SignInController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}