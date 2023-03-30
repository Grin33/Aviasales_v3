using Microsoft.AspNetCore.Mvc;

namespace Aviasales_v3.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
