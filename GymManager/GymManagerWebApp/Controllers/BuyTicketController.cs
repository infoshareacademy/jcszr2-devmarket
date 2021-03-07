using Microsoft.AspNetCore.Mvc;

namespace GymManagerWebApp.Controllers
{
    public class BuyTicketController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}