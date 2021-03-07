using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}