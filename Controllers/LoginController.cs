using Microsoft.AspNetCore.Mvc;

namespace IT04_1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
