using Microsoft.AspNetCore.Mvc;
using BBC.Shared;
using BBC.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using BBC.Client.Pages;
using BBC.Shared.Models;
using Menu = BBC.Shared.Models.Menu;

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

        [HttpGet("{type}")]
        public ActionResult<List<Menu>> Get(string type)
        {

            drinkHelper getDrinks = new drinkHelper();
          
            

            List<Menu> returnObj = new List<Menu>();

            switch (type)
            {
                case "popular":
                    returnObj = getDrinks.GetMenu(type);
                    return returnObj.Count > 0 ? Ok(returnObj) : NotFound("Popular Drinks Not Found");
                case "full_menu":
                    returnObj = getDrinks.GetMenu(type);
                    return returnObj.Count > 0 ? Ok(returnObj) : NotFound("Full menu Not Found");
                case "shot":
                    returnObj = getDrinks.GetMenu(type);
                    return returnObj.Count > 0 ? Ok(returnObj) : NotFound("Shot menu Not Found");
                case "cocktail":
                    returnObj = getDrinks.GetMenu(type);
                    return returnObj.Count > 0 ? Ok(returnObj) : NotFound("Cocktail menu Not Found");
                default:
                    return NotFound("Type does not match");

            }

        }

        }
}
