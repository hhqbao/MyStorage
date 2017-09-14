namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesProductsAndPricesAndSuppliersPrices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        ImageUrl = c.String(),
                        NumbersInStock = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CategoryTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId)
                .Index(t => t.CategoryId)
                .Index(t => t.CategoryTypeId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Suppliers_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers_Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers_Products", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Prices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryTypeId", "dbo.CategoryTypes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Suppliers_Products", new[] { "ProductId" });
            DropIndex("dbo.Suppliers_Products", new[] { "SupplierId" });
            DropIndex("dbo.Prices", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryTypeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Suppliers_Products");
            DropTable("dbo.Prices");
            DropTable("dbo.Products");
        }
    }
}
