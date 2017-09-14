namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageUrlFromProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
        }
    }
}
