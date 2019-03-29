using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LognReg.Models;
using Microsoft.AspNetCore.Identity;

namespace LognReg.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("submit")]
        public IActionResult Register(RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                List<Dictionary<string,object>> users = DbConnector.Query($"SELECT id, password FROM user WHERE email = '{user.Email}'");   

                if(users.Count == 0)
                {
                    RegisterUser(user);
                    return RedirectToAction("Success");
                }

                ModelState.AddModelError("LogEmail", "Email already exists");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            List<Dictionary<string,object>> users = DbConnector.Query($"SELECT id, password FROM user WHERE email = '{user.LogEmail}'");

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            if((users.Count == 0 || user.LogPassword == null) || hasher.VerifyHashedPassword(user, (string)users[0]["password"], user.LogPassword) == 0)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
            }
            if(ModelState.IsValid)
            {
                //valid user info so proceed
                HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        public void RegisterUser(RegisterUser user)
        {
            PasswordHasher<RegisterUser> hasher = new PasswordHasher<RegisterUser>();
            string hashed = hasher.HashPassword(user, user.Password);

            string query = $@"INSERT INTO user (firstName, lastName, email, password, create_at, updated_at)
                            VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{hashed}', NOW(), NOW());
                            SELECT LAST_INSERT_ID() as id";
            HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
        } 


        [HttpGet]
        [Route("success")]
        public string Success()
        {
            return "Success!";
        }
    }
}