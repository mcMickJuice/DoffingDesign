namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelsForProjectAndCollections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectItem", "Project_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ThirdPartySiteInfo", "Project_Id", c => c.Int());
            CreateIndex("dbo.ProjectItem", "Project_Id");
            CreateIndex("dbo.ThirdPartySiteInfo", "Project_Id");
            AddForeignKey("dbo.ProjectItem", "Project_Id", "dbo.Project", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.ThirdPartySiteInfo", "Project_Id", "dbo.Project", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThirdPartySiteInfo", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.ProjectItem", "Project_Id", "dbo.Project");
            DropIndex("dbo.ThirdPartySiteInfo", new[] { "Project_Id" });
            DropIndex("dbo.ProjectItem", new[] { "Project_Id" });
            DropColumn("dbo.ThirdPartySiteInfo", "Project_Id");
            DropColumn("dbo.ProjectItem", "Project_Id");
        }
    }
}
