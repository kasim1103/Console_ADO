namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingVirtualSupplierId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Suppliers_id", c => c.Int());
            CreateIndex("dbo.Items", "Suppliers_id");
            AddForeignKey("dbo.Items", "Suppliers_id", "dbo.Suppliers", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Suppliers_id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "Suppliers_id" });
            DropColumn("dbo.Items", "Suppliers_id");
        }
    }
}
