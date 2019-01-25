namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "price");
        }
    }
}
