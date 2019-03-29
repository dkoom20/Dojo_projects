using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace QtDojo.Controllers
{
    public class QtDojoController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            if(TempData["Error"] != null){
                ViewBag.Error = TempData["Error"];
            }
            return View();
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes(){
            //Get quotes from DB
            string query = "SELECT * FROM quotes";
            var quotes = DbConnector.Query(query);

            //Sort quotes by date added
            quotes = quotes.OrderByDescending((quote) => quote["added_date"]).ToList();

            //Format dates
            foreach(var quote in quotes){
                DateTime created = (DateTime)quote["added_date"];
                string formatted_created = String.Format("{0:h:mm tt MMMM d yyyy}", created);
                quote["added_date"] = formatted_created;
            }

            ViewBag.Quotes = quotes;
            return View();
        }
        
        [HttpPost]
        [Route("/quotes")]
        public IActionResult Create(string name, string content){
            if(name == "" || name == null) {
                TempData["Error"] = "Name is mandatory!";
                return RedirectToAction("Index");
            }
            if(content == "" || content == null) {
                TempData["Error"] = "Quote must be provided!";
                return RedirectToAction("Index");
            }
            //Add the quote to the database
            string query = $"INSERT INTO quotes (source, text, added_date) VALUES ('{name}', '{content}', NOW());";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");    
        }
    }
}
