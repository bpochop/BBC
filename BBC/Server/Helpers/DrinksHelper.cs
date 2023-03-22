using BBC.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBC.Server.Models;
using Microsoft.VisualBasic;


namespace BBC.Server.Helpers
{
    public class drinkHelper
    {

        

        public List<Menu> GetMenu(string type)
        {
            List<Menu> theMenu = new List<Menu>(); 
            var configBuilder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = configBuilder.Build();

            // Retrieve the connection string for the SQLite database
            var connectionString = configuration.GetConnectionString("SqlLiteConnection");

            // Create a DbContextOptions instance with the connection string
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>()
                .UseSqlite(connectionString);

            Console.WriteLine("TEST TEST TEST LOOOK HEREERERERERERE");
            Console.WriteLine(type);
     

            // Create a new DbContext instance using the options
            using (var db = new BBC_DB(optionsBuilder.Options))
            {

                switch (type)
                {
                    case "popular":
                        theMenu = getPopularDrinks(db);
                        break;
                    case "full_menu":
                        theMenu = getFullMenu(db);
                        break;
                    case "shot":
                        theMenu = getShots(db);
                        break;
                    case "cocktail":
                        theMenu = getCocktails(db);
                        break;
                    default:
                        theMenu = null;
                        break;
                }
            }

            return theMenu;
        }

        public List<Menu> getPopularDrinks(BBC_DB db)
        {
            
            var drinks = db.Menus
                .OrderByDescending(d => d.Count)
                .Take(6)
                .ToList();

            Console.WriteLine(drinks.Count);

            return drinks;
        }

        public List<Menu> getShots(BBC_DB db)
        {
            List<Ratio> strings = new List<Ratio>();
            List<Menu> returnObj = new List<Menu>();

            var ingredients = getIngredientsInPumps(db);


            strings = db.Ratios.ToList(); 

            foreach(var r in strings)
            {
                if (ingredients.Contains(r.Ingredient))
                {

                }
            }

            //strings = db.Ratios
            //    .Where(r => r.Ingredient.All(i => ingredients.Contains(i.ToString())))
            //    .ToList();  


         


            return returnObj;
        }

        public List<Menu> getCocktails(BBC_DB db)
        {
            List<Menu> strings = new List<Menu>();


            var ingredients = getIngredientsInPumps(db);


            strings = db.Menus.Where(d => !ingredients.Except(db.Pumps.Select(p => p.IngredientId)).Any())
                .ToList();


            return strings;
        }

        public List<Menu> getFullMenu(BBC_DB db)
        {
            List<Menu> strings = new List<Menu>();

            var ingredients = getIngredientsInPumps(db);


            strings = db.Menus
                 .Where(d => !ingredients.Except(db.Pumps.Select(p => p.IngredientId)).Any())
                .ToList();

            return strings;
        }



     
        public List<string> getIngredientsInPumps(BBC_DB db)
        {
            List<Pump> ingredients = new List<Pump>();
            List<string> returnString = new List<string>(); 

            ingredients = db.Pumps.ToList();

            foreach (var idx in ingredients)
            {
                returnString.Add(idx.IngredientId.ToString());  
            }

            return returnString; 

        }
    }
}
