namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStockQuantityFromProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "NumbersInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "NumbersInStock", c => c.Double(nullable: false));
        }
    }
}
