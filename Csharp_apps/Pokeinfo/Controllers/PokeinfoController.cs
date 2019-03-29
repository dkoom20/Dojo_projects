using Microsoft.AspNetCore.Mvc;

namespace Pokeinfo.Controllers

{
    public class PokeinfoController : Controller
    {
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult GetInfo(int id)
        {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }
}