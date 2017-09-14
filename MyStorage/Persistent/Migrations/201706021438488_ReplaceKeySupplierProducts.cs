namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceKeySupplierProducts : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Suppliers_Products");
            AddPrimaryKey("dbo.Suppliers_Products", new[] { "SupplierId", "ProductId" });
            DropColumn("dbo.Suppliers_Products", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers_Products", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Suppliers_Products");
            AddPrimaryKey("dbo.Suppliers_Products", "Id");
        }
    }
}
