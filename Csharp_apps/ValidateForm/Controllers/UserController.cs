using Microsoft.AspNetCore.Mvc;
using ValidateForm.Models;
namespace ValidateForm.Controllers {
    
    public class UserController : Controller {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string first_name, string last_name, string email, int age, string password)
        {
            User NewUser = new User {
                FirstName = first_name,
                LastName = last_name,
                Email = email,
                Age = age,
                Password = password
            };
            
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.ModelFields = ModelState.Values;
                return View();
            }
            else
            {
                return RedirectToAction("Success");  
            }

        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}