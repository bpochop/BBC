using BBC.Shared.BBC.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC.Server.Helpers
{
    public class drinkHelper
    {

        public DbSet<Menu> theMenu { get; set; }
        public DbSet<IngredientId> Ingredients { get; set; }

        public DbSet<Menu> GetMenu(string type)
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

            // Create a new DbContext instance using the options
            using (var context = new DbContext(optionsBuilder.Options))
            {

                //var items = context.Menu.ToList(); 
            }

            return theMenu;
        }
    }
}
