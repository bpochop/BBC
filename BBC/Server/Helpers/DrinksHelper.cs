using BBC.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBC.Server.Models;


namespace BBC.Server.Helpers
{
    public class drinkHelper
    {

        public List<Menu>? theMenu { get; set; }
        public List<IngredientId>? Ingredients { get; set; }

        public List<Menu> GetMenu(string type)
        {

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

        public List<Menu> getShots(DbContext db)
        {
            List<Menu> strings = new List<Menu>();


            return strings;
        }

        public List<Menu> getCocktails(DbContext db)
        {
            List<Menu> strings = new List<Menu>();


            return strings;
        }

        public List<Menu> getFullMenu(BBC_DB db)
        {
           var drinks = db.Menus.ToList();


            return drinks;
        }



        public List<Menu> formatDbSet(DbSet<Menu> dbSet)
        {
            List<Menu> strings = new List<Menu>();


            return strings; 

        }
    }
}
