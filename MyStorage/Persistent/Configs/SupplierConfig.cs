using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyStorage.Core.Models;

namespace MyStorage.Persistent.Configs
{
    public class SupplierConfig : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfig()
        {
            ToTable("Suppliers");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}