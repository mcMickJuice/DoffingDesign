using System.Collections.Generic;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service.Models;
using Project = DoffingDesign.DAL.EntityModels.Project;
using ProjectItem = DoffingDesign.DAL.EntityModels.ProjectItem;

namespace DoffingDesign.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoffingDesign.DAL.EntityModels.DoffingDotComModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoffingDesign.DAL.EntityModels.DoffingDotComModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.


            var leftTemplate = new ProjectTemplate {IsAvailable = true, TemplateName = "DescriptionOnLeft"};
            var rightTemplate = new ProjectTemplate {IsAvailable = true, TemplateName = "DescriptionOnRight"};

            context.ProjectTemplates.AddOrUpdate(p => p.TemplateName,
                leftTemplate,
                rightTemplate
                );

//            context.SaveChanges();

            var fancyPattern1 = new ProjectItem
            {
                AltText = "Floral Pattern",
                ImageCaption = "This is a nice Floral Pattern",
                ImageName = "Floral Pattern",
                ImageUrl = "http://i.imgur.com/OMdaYXz.jpg",
                IsThumb = true
            };

            var fancyPattern2 = new ProjectItem()
            {
                AltText = "Aaron Rodgers",
                ImageCaption = "Dope QB",
                ImageName = "Aaron Rodgers is a good QB",
                ImageUrl =
                    "http://blogstorage.s3.amazonaws.com/upload/SportsBlogcom/1743782/0289659001427124369_filepicker.jpg"
            };

            var fancyDrawing1 = new ProjectItem
            {
                AltText = "Drawing Girl",
                ImageCaption = "This is a girl that is drawn",
                ImageName = "Drawing Girl",
                ImageUrl = "http://i.imgur.com/MsVyZ5z.jpg",
                IsThumb = true
            };

            context.ProjectItems.AddOrUpdate(p => p.ImageName,
                fancyPattern1,
                fancyPattern2,
                fancyDrawing1);

//            context.SaveChanges();

            var society6Project1 = new ThirdPartySiteInfo
            {
                SiteId = "123Society6FakeId",
                ThirdPartySiteType = ThirdPartySiteType.Society6
            };

            var amazonProject1 = new ThirdPartySiteInfo
            {
                SiteId = "AmazonFakeID",
                ThirdPartySiteType = ThirdPartySiteType.Amazon
            };

            context.ThirdPartySiteInfos.AddOrUpdate(p => p.SiteId,
                society6Project1,
                amazonProject1);

//            context.SaveChanges();

            var drawingProject = new Project
            {
                ProjectType = ProjectType.Drawing,
                Title = "Girl being Drawn",
                SortOrder = 1,
                ProjectMarkdown = "##This is the title\r\nThis is the main paragraph",
                ProjectItems = new List<ProjectItem>
                {
                    fancyDrawing1
                },
                ProjectTemplate = leftTemplate,
                ThirdPartyInfos = new List<ThirdPartySiteInfo>
                {
                    society6Project1,
                    amazonProject1
                },
                IsActive = true
            };

            drawingProject.AppSlug = createSlug(drawingProject.Title);

            var patternProject = new Project
            {
                ProjectType = ProjectType.Vector,
                Title = "Neat Pattern Project",
                SortOrder = 1,
                ProjectMarkdown = "###Here's the title of Neat PAttern Project\r\n* item1 \r\n* item2",
                ProjectItems = new List<ProjectItem>
                {
                    fancyPattern1,
                    fancyPattern2
                },
                ProjectTemplate = rightTemplate,
                IsActive = true
            };

            patternProject.AppSlug = createSlug(patternProject.Title);

            context.Projects.AddOrUpdate(p => p.Title,
                drawingProject,
                patternProject);

//            context.SaveChanges();
        }

        private string createSlug(string projectTitle)
        {
            //should be whole list of chars not allowed in url
            var alteredString = projectTitle.Replace("&", "");
            var splitsOnSpace = projectTitle.Split(' ').ToList();
            //only first four
            splitsOnSpace = splitsOnSpace.Take(4).ToList();
            return string.Join("-", splitsOnSpace);
        }
    }
}
