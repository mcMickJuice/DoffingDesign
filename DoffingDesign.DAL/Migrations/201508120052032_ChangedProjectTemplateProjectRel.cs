namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProjectTemplateProjectRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Project", "ProjectTemplate_Id", "dbo.ProjectTemplate");
            DropIndex("dbo.Project", new[] { "ProjectTemplate_Id" });
            AlterColumn("dbo.Project", "ProjectTemplate_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Project", "ProjectTemplate_Id");
            AddForeignKey("dbo.Project", "ProjectTemplate_Id", "dbo.ProjectTemplate", "ProjectTemplateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "ProjectTemplate_Id", "dbo.ProjectTemplate");
            DropIndex("dbo.Project", new[] { "ProjectTemplate_Id" });
            AlterColumn("dbo.Project", "ProjectTemplate_Id", c => c.Int());
            CreateIndex("dbo.Project", "ProjectTemplate_Id");
            AddForeignKey("dbo.Project", "ProjectTemplate_Id", "dbo.ProjectTemplate", "ProjectTemplateId");
        }
    }
}
