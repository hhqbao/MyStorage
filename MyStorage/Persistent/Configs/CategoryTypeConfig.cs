using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyStorage.Core.Models;

namespace MyStorage.Persistent.Configs
{
    public class CategoryTypeConfig : EntityTypeConfiguration<CategoryType>
    {
        public CategoryTypeConfig()
        {
            ToTable("CategoryTypes");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(m => m.Category)
                .WithMany(c => c.CategoryTypes)
                .HasForeignKey(m => m.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}