using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrightIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BrightIdeas.Controllers
{
    public class UserController : Controller
    {
        private BrightIdeasContext _context;

        public UserController(BrightIdeasContext context)
        {   
            _context = context;
        }   


        public User Logged_user
        {
        get {return _context.user.SingleOrDefault
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


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser ViewModel)
        {
            if (ModelState.IsValid)
            {
                if(ViewModel.password != ViewModel.pw_confirm)
                {
                    TempData["Error"] = "Invalid Registration - Password not confirmed";
                }
                else
                {
          //        User newUser = _context.user.Where(u => u.email == model.email).SingleOrDefault();
          //    }

                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    User user = new User();

                    user.password = Hasher.HashPassword(user, ViewModel.password);   

                    user.name = ViewModel.name;
                    user.alias = ViewModel.alias;
                    user.email = ViewModel.email;
                    user.created_at = DateTime.Now;

                    _context.user.Add(user);
                    _context.SaveChanges();

                    int UserId = _context.user.Last().id;

                    HttpContext.Session.SetInt32("UserId", UserId);
           
                    return RedirectToAction("IdeasDashboard", "Ideas");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [Route("AttemptLogin")]
        public IActionResult AttemptLogin(LoginUser ViewModel)
        {
            if (ModelState.IsValid)
            {
                User currUser = _context.user.Where(u => u.email == ViewModel.email).SingleOrDefault();

                if (currUser.email != null && ViewModel.password != null &&
                    currUser.email != ""   && ViewModel.password != "")
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(currUser, currUser.password, ViewModel.password))
                    {
                        HttpContext.Session.SetInt32("UserId", currUser.id);
                        return RedirectToAction("IdeasDashboard", "Ideas");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Login - Email / Password Combination";
                    }
                }    
                else
                {
                    TempData["Error"] = "Please enter Email / Password";
                }
            }
            return View("Index");
        }
    }
}