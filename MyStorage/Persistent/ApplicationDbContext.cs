using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyStorage.Core.Models;
using MyStorage.Persistent.Configs;

namespace MyStorage.Persistent
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockChange> StockChanges { get; set; }     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new CategoryTypeConfig());
            modelBuilder.Configurations.Add(new ProductConfig());  
            modelBuilder.Configurations.Add(new StockConfig());  
            modelBuilder.Configurations.Add(new StockChangeConfig());  
                                  
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}