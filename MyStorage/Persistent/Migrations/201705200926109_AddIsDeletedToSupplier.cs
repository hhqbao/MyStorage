namespace MyStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedToSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsDeleted");
        }
    }
}
