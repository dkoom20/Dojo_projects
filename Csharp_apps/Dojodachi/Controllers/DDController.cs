using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public class DDController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<DD>("Dojodachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new DD());
            }

            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<DD>("Dojodachi");
            ViewBag.Message = "Dojodachi has arrived";
            ViewBag.GameStatus = "running";
            return View();
        }

        [HttpPost]
        [Route("performAction")]
        public IActionResult PerformAction(string action)
        {
            DD EditDachi = HttpContext.Session.GetObjectFromJson<DD>("Dojodachi");
            Random RandObject = new Random();
            ViewBag.GameStatus = "running";
            switch(action)
            {
                case "feed":
                    if(EditDachi.Meals > 0){
                        EditDachi.Meals -= 1;
                        if(RandObject.Next(0, 4) > 0)
                        {
                            EditDachi.Fullness += RandObject.Next(5, 11);
                            ViewBag.Message = "Dojodachi ate up";
                        }
                        else
                        {
                            ViewBag.Message = "Dojodachi has a tummy ache";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "The cupboard is bare";
                    }
                    break;
                case "play":
                    if(EditDachi.Energy > 4)
                    {
                        EditDachi.Energy -= 5;
                        if(RandObject.Next(0, 4) > 0)
                        {
                            EditDachi.Happiness += RandObject.Next(5, 11);
                            ViewBag.Message = "Dojodachi had fun playing!";
                        }
                        else
                        {
                            ViewBag.Message = "Dojodachi didn't play";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Need more energy";
                    }

                    break;
                case "work":
                    if(EditDachi.Energy > 4)
                    {
                        EditDachi.Energy -= 5;
                        EditDachi.Meals += RandObject.Next(1, 4);
                        ViewBag.Message = "Working hard for food";
                    }
                    else
                    {
                        ViewBag.Message = "Need more energy";
                    }
                    break;
                case "sleep":
                    EditDachi.Energy += 15;
                    EditDachi.Fullness -= 5;
                    EditDachi.Happiness -= 5;
                    ViewBag.Message = "Dojodachi is well rested.";
                    break;
                default:
                    ViewBag.Message = "something went wrong";
                    break;

            }
            if(EditDachi.Fullness < 1 || EditDachi.Happiness < 1)
            {
                ViewBag.Message = "Oh no! Your Dojodachi has died...";
                ViewBag.GameStatus = "over";
            }
            else if(EditDachi.Fullness > 99 && EditDachi.Happiness > 99)
            {
                ViewBag.Message = "Congratulations ------ You win!";
                ViewBag.GameStatus = "over";
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", EditDachi);
            ViewBag.Dojodachi = EditDachi;
            return View("Index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}