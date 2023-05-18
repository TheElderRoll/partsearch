using System;
using Microsoft.AspNetCore.Mvc;
using partsearch.Domain;

namespace partsearch.Controllers
{
    public class PartsController : Controller
    {
        private readonly DataManager dataManager;

        public PartsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Parts.GetPartById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageParts");
            return View(dataManager.Parts.GetParts());
        }
        [HttpPost]
        public IActionResult FindByCode(string code)
        {
            System.Diagnostics.Debug.WriteLine(code);
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageParts");
            return View("Index", dataManager.Parts.GetPartsByCode(code));
        }
    }
}