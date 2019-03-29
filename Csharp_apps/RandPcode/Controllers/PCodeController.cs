using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandPcode.Controllers
{
    public class PCodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //get session value
            int? genCount = HttpContext.Session.GetInt32("genCount");
            if(genCount == null)
            {
                genCount = 0;
            }
            genCount += 1;
            // generate 14 character code - randomly
            string CharPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string PassCode = "";
            Random Rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                PassCode = PassCode + CharPool[Rand.Next(0, CharPool.Length)];
            }
            //set ViewBag values to pass to view
            ViewBag.PassCode = PassCode;
            ViewBag.genCount = genCount;

            //set session value
            HttpContext.Session.SetInt32("genCount", (int)genCount);
            return View();
        }
    }
}