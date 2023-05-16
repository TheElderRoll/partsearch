using Microsoft.AspNetCore.Mvc;
using partsearch.Domain;

namespace partsearch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Parts.GetParts());
        }
    }
}