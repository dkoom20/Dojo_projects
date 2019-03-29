using Microsoft.AspNetCore.Mvc;


namespace Time_Display.Controllers
{
    public class TDController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}