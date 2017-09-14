using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyStorage.Core.Models;

namespace MyStorage.Persistent.Configs
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            ToTable("Products");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            

            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);            

            HasRequired(m => m.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(m => m.CategoryId)
                .WillCascadeOnDelete(false);

            HasOptional(m => m.CategoryType)
                .WithMany(t => t.Products)
                .HasForeignKey(m => m.CategoryTypeId)
                .WillCascadeOnDelete(false);

        }
    }
}