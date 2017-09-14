using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MyStorage.Core.Models;

namespace MyStorage.Persistent.Configs
{
    public class StockChangeConfig : EntityTypeConfiguration<StockChange>
    {
        public StockChangeConfig()
        {
            ToTable("StockChanges");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}