using System.Linq;
using System.Web;
using MyStorage.Core.Models;
using MyStorage.Persistent;

namespace MyStorage.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {       
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Persistent/Migrations";            
        }

        protected override void Seed(ApplicationDbContext context)
        {
            
        }
    }
}
