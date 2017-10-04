namespace DBLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "TestColumn1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TestColumn1", c => c.String());
        }
    }
}
