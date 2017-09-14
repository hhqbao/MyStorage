namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBarCodeFromProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "BarCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "BarCode", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
