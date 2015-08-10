namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "AppSlug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "AppSlug");
        }
    }
}
