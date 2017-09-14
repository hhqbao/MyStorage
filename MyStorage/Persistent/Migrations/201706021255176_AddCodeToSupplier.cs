namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeToSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Code", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "Code");
        }
    }
}
