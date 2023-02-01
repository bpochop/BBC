using Microsoft.AspNetCore.Mvc;
using BBC.Shared;

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
            var drinks = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "drank", "pooru" };

            if (drinks is not null)
            {
                return Ok(drinks);
            }
            return NotFound("Coffeee not found");
        }

        [HttpGet]
        public ActionResult Get(string type)
        {
            var Cocktails = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "drank", "pooru" };

            var Shots = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "drank", "pooru" };

            var fullMenu = new List<string> { "drink1", "drink2", "drink2electricbugaloo", "drank", "pooru" };

            if (type is not null && type == "cocktails")
            {
                return Ok(Cocktails);
            }
            else if(type is not null && type == "shots")
            {
                return Ok(Shots);

            }
            else
            {
                return Ok(fullMenu);
            }


            return NotFound("Coffeee not found");
        }
    }
}
