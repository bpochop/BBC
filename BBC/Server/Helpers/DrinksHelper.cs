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

        

        public List<Menuitem> GetMenu(string type)
        {
            List<Menuitem> theMenu = new List<Menuitem>(); 
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

        public List<Menuitem> getPopularDrinks(BBC_DB db)
        {
            
            var drinks = db.Menus
                .OrderByDescending(d => d.Count)
                .Take(6)
                .ToList();

            Console.WriteLine(drinks.Count);

            return drinks;
        }

        public List<Menuitem> getShots(BBC_DB db)
        {
            List<Ratio> strings = new List<Ratio>();
            List<Menuitem> returnObj = new List<Menuitem>();

            //var ingredients = getIngredientsInPumps(db);


            List<Pump> activePumps = getPumpIngredients(db);


            List<Menuitem> shotMenu = db.Menus
                .Where(d => d.Type == 'S')
                .ToList();


            List<Ratio> ratios = db.Ratios
                .ToList();



            foreach (var item in shotMenu)
            {
                var query = from r in ratios
                            where r.MenuId == item.Id
                            select new Menuitem
                            {
                                Id = item.Id,
                                Name = item.Name,
                                CreatorId = item.CreatorId,

                                //drink_id = r.drink_id,
                                amount = r.amount,
                                pump_id = (from p in activePumps where p.drink_id == r.drink_id select p.id).FirstOrDefault(),
                                name = (from d in menuDrinks where d.id == r.drink_id select d.name).FirstOrDefault(),
                            };
                item.parts = query.ToList();
            }

            foreach (MenuItem item in mainMenu)
            {
                Console.WriteLine($"For the drink {item.name} it has {item.parts.Count} part(s) to the drink, it currently {(item.CanMake() ? "can" : "cant")} be made.");
                foreach (Part part in item.parts)
                {
                    Console.WriteLine($"Drink {part.name} is {part.amount} parts of the drink. Using Pump {part.pump_id}");
                }
                Console.WriteLine();
            }



            return returnObj;
        }

        public List<Menuitem> getCocktails(BBC_DB db)
        {
            List<Menuitem> strings = new List<Menuitem>();


            var ingredients = getPumpIngredients(db);


            strings = db.Menus.Where(d => !ingredients.Except(db.Pumps.Select(p => p.IngredientId)).Any())
                .ToList();


            return strings;
        }

        public List<Menuitem> getFullMenu(BBC_DB db)
        {
            List<Menuitem> strings = new List<Menuitem>();

            var ingredients = getPumpIngredients(db);


            strings = db.Menus
                 .Where(d => !ingredients.Except(db.Pumps.Select(p => p.IngredientId)).Any())
                .ToList();

            return strings;
        }



     
        public List<Pump> getPumpIngredients(BBC_DB db)
        {
            List<Pump> ingredients = new List<Pump>();
            List<Pump> returnString = new List<Pump>(); 

            ingredients = db.Pumps.ToList();

            foreach (var idx in ingredients)
            {
                returnString.Add(idx.IngredientId.ToString());  
            }

            return returnString; 

        }
    }
}
