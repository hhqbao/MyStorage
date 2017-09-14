namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTableStockChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        ChangeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockChanges");
        }
    }
}
