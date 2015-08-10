namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectItem",
                c => new
                    {
                        ProjectItemId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImageCaption = c.String(),
                        AltText = c.String(),
                        IsThumb = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ProjectItemId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectType = c.Int(nullable: false),
                        Title = c.String(),
                        SortOrder = c.Int(nullable: false),
                        ProjectMarkdown = c.String(),
                        ProjectTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ProjectTemplate", t => t.ProjectTemplate_Id)
                .Index(t => t.ProjectTemplate_Id);
            
            CreateTable(
                "dbo.ProjectTemplate",
                c => new
                    {
                        ProjectTemplateId = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTemplateId);
            
            CreateTable(
                "dbo.ThirdPartySiteInfo",
                c => new
                    {
                        ThirdPartySiteInfoId = c.Int(nullable: false, identity: true),
                        SiteId = c.String(),
                        ThirdPartySiteType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThirdPartySiteInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "ProjectTemplate_Id", "dbo.ProjectTemplate");
            DropIndex("dbo.Project", new[] { "ProjectTemplate_Id" });
            DropTable("dbo.ThirdPartySiteInfo");
            DropTable("dbo.ProjectTemplate");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectItem");
        }
    }
}
