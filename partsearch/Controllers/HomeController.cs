using Microsoft.AspNetCore.Mvc;

namespace partsearch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
