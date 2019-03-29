using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auctions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Controllers
{
    public class UserController : Controller
    {
        private AuctionsContext _context;

        public UserController(AuctionsContext context)
        {   
            _context = context;
        }   


        public User Logged_user
        {
        get {return _context.users.SingleOrDefault
            (u => u.id == (int)HttpContext.Session.GetInt32("id"));
            }
        }
 

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("Index");
        }


 //       [HttpGet]
 //       [Route("Login")]
 //       public IActionResult Login()
 //       {
 //           return View("Login");
 //       }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User user = new User();

                user.password = Hasher.HashPassword(user, model.password);   

                Console.WriteLine("=========== hashed password =======================================");
                Console.WriteLine("==");
                Console.WriteLine(user.password);
                Console.WriteLine("==");
                Console.WriteLine("===================================================================");

                user.username = model.username;
                user.first_name = model.first_name;
                user.last_name = model.last_name;
                user.created_at = DateTime.Now;

                int Initial_funding = 1000;
                user.available_funds = Initial_funding;

                _context.users.Add(user);
                _context.SaveChanges();

                int UserId = _context.users.Last().id;

                HttpContext.Session.SetInt32("UserId", UserId);

                return RedirectToAction("GetAuctions", "RunAuctions");
            }
            return View("Index", model);
        }

        [HttpPost]
        [Route("AttemptLogin")]
        public IActionResult AttemptLogin(User model)
        {
            if (ModelState.IsValid)
            {
                User currUser = _context.users.Where(u => u.username == model.username).SingleOrDefault();

                if (currUser.username != null && model.password != null &&
                    currUser.username != ""   && model.password != "")
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(currUser, currUser.password, model.password))
                    {
                        HttpContext.Session.SetInt32("UserId", currUser.id);
                        return RedirectToAction("GetAuctions", "RunAuctions");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Login - Username / Password Combination";
                    }
                }    
                else
                {
                    TempData["Error"] = "Please enter Login / Password";
                }
            }
            return View("Index");
        }
    }
}