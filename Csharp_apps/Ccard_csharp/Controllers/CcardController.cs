using Microsoft.AspNetCore.Mvc;

namespace Ccard_csharp.Controllers
{
    public class CcardController : Controller
    {

        [HttpGet]
        [Route("/{FName}/{LName}/{Age}/{FColor}")]
        public JsonResult CallCard(string FName, string LName, int Age, string FColor)
        {
            return Json(new {FirstName = FName, LastName = LName, Age = Age, FavoriteColor = FColor});
        }
    }
}