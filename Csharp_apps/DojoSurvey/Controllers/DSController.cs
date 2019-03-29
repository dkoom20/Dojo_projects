using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class DSController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("submitdis")]
        public IActionResult Process(string Name, string Location, string Language, string Comment)
        {
            ViewBag.Errors = new List<string>();

            if(Name == null)
            {
                ViewBag.Errors.Add("Please enter name");
            }

            if(Location == null)
            {
                ViewBag.Errors.Add("Please select location");
            }

            if(Language == null)
            {
                ViewBag.Errors.Add("Please select language");
            }

            if(ViewBag.Errors.Count > 0)
            {
                return View("Index");
            }

            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            
            return View("Submitted");
        }
    }
}
