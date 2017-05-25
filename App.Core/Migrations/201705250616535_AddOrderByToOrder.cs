namespace App.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderByToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderBy");
        }
    }
}
