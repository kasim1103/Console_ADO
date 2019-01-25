namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Items_id = c.Int(),
                        Transactions_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Items", t => t.Items_id)
                .ForeignKey("dbo.Transactions", t => t.Transactions_id)
                .Index(t => t.Items_id)
                .Index(t => t.Transactions_id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionItems", "Transactions_id", "dbo.Transactions");
            DropForeignKey("dbo.TransactionItems", "Items_id", "dbo.Items");
            DropIndex("dbo.TransactionItems", new[] { "Transactions_id" });
            DropIndex("dbo.TransactionItems", new[] { "Items_id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionItems");
        }
    }
}
