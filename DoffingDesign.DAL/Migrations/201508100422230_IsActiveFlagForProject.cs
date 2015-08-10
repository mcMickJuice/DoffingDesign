namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveFlagForProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "IsActive");
        }
    }
}
