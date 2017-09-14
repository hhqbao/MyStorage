namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableSupplierProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers_Products", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Suppliers_Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Suppliers_Products", new[] { "SupplierId" });
            DropIndex("dbo.Suppliers_Products", new[] { "ProductId" });
            DropTable("dbo.Suppliers_Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Suppliers_Products",
                c => new
                    {
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierId, t.ProductId });
            
            CreateIndex("dbo.Suppliers_Products", "ProductId");
            CreateIndex("dbo.Suppliers_Products", "SupplierId");
            AddForeignKey("dbo.Suppliers_Products", "SupplierId", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.Suppliers_Products", "ProductId", "dbo.Products", "Id");
        }
    }
}
