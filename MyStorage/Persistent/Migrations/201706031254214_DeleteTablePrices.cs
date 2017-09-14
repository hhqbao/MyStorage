namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTablePrices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "ProductId", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "ProductId" });
            DropTable("dbo.Prices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Prices", "ProductId");
            AddForeignKey("dbo.Prices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
