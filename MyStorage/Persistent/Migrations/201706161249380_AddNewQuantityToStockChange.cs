namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewQuantityToStockChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockChanges", "NewQuantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockChanges", "NewQuantity");
        }
    }
}
