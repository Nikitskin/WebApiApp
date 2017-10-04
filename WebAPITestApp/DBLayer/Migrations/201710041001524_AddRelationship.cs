namespace DBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "User_Id", c => c.Int());
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Orders", "ProductName");
            DropColumn("dbo.Orders", "Value");
            DropColumn("dbo.Users", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Value", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "ProductName", c => c.String());
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Products", "Order_Id");
            DropColumn("dbo.Orders", "User_Id");
        }
    }
}
