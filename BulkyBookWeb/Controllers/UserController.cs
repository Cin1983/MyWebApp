using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
