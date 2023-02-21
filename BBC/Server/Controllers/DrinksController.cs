using Microsoft.AspNetCore.Mvc;
using BBC.Shared;
using BBC.Server.Helpers;

namespace BBC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {

            drinkHelper getDrinks = new drinkHelper();

            var test = getDrinks.GetMenu("Shot");

            var drinks = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "drank", "pooru" };

            if (drinks is not null)
            {
                return Ok(drinks);
            }
            return NotFound("Coffeee not found");
        }


        [HttpGet("GetPopularDrinks")]
        public ActionResult GetPopularDrinks()
        {

            //drinkHelper getDrinks = new drinkHelper();

            //var test = getDrinks.GetMenu("Shot");

            var drinks = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "test3", "pooru" };

            if (drinks is not null)
            {
                return Ok(drinks);
            }
            return NotFound("Coffeee not found");
        }


    }
}
