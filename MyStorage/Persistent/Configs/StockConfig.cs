using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyStorage.Core.Models;

namespace MyStorage.Persistent.Configs
{
    public class StockConfig : EntityTypeConfiguration<Stock>
    {
        public StockConfig()
        {
            ToTable("Stocks");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.StockCode)
                .IsRequired()
                .HasMaxLength(255);

            Property(m => m.BarCode)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(m => m.Supplier)
                .WithMany(s => s.Stocks)
                .HasForeignKey(m => m.SupplierId)
                .WillCascadeOnDelete(false);

            HasRequired(m => m.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(m => m.ProductId)
                .WillCascadeOnDelete(false);            
        }
    }
}