using Microsoft.AspNetCore.Mvc;

namespace School_Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
