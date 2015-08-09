using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.Service.Models;

namespace DoffingDesign.Service
{
    public class InMemoryProjectService: IProjectService
    {
        private static IEnumerable<ProjectItem> _projectItems = new List<ProjectItem>
        {
            new ProjectItem
            {
                AltText = "ProjectItem 1",
                ImageCaption = "This is the first Project Item",
                ImageName = "ProjectItem 1 Image NAme",
                ImageUrl = "http://i.imgur.com/MsVyZ5z.jpg",
                IsThumb = false
            },
            new ProjectItem
            {
                AltText = "ProjectItem 2",
                ImageCaption = "This is the secnd Project Item",
                ImageName = "ProjectItem 2 Image NAme",
                ImageUrl = "http://i.imgur.com/MsVyZ5z.jpg",
                IsThumb = false
            },
            new ProjectItem
            {
                AltText = "ProjectItem 3",
                ImageCaption = "This is the third Project Item",
                ImageName = "ProjectItem 13 Image NAme",
                ImageUrl = "http://i.imgur.com/MsVyZ5z.jpg",
                IsThumb = false
            }

        };

        private static IEnumerable<Project> _allProjects = new List<Project>
        {
            new Project()
            {
                ProjectId = "project1",
                Title = "Project 1",
                ProjectHtml = "<h2>Project 1 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 1,
                ProjectItems = _projectItems,
                ViewName = "DescriptionOnRight"
            },
            new Project()
            {
                ProjectId = "project2",
                Title ="Project 2",
                ProjectHtml = "<h2>Project 2 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 2,
                ProjectItems = _projectItems,
                ViewName = "DescriptionOnLeft"
            },
            new Project()
            {
                ProjectId = "project3",
                Title = "Project 3",
                ProjectHtml = "<h2>Project 3 Vector Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Vector,
                SortOrder = 3,
                ProjectItems = _projectItems,
                ViewName = "DescriptionOnLeft"
            },
            new Project()
            {
                ProjectId = "project2",
                Title ="Project 2",
                ProjectHtml = "<h2>Project 4 Vector Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Vector,
                SortOrder = 2,
                ProjectItems = _projectItems,
                ViewName = "DescriptionOnRight"
            },
            new Project()
            {
                ProjectId = "project3",
                Title = "Project 3",
                ProjectHtml = "<h2>Project 5 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 3,
                ProjectItems = _projectItems,
                ViewName = "DescriptionOnLeft"
            },

        };

        public IEnumerable<Project> GetActiveProjects()
        {
            return _allProjects;
        }

        public Project GetProjectByName(string projectName)
        {
            var project = _allProjects.FirstOrDefault(p => p.ProjectId == projectName);

            return project;
        }

        public IEnumerable<Project> GetProjectByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByType(string projectType)
        {
            IEnumerable<Project> projects;
            if (string.Equals(projectType, "Drawings"))
            {
                projects = _allProjects.Where(p => p.ProjectType == ProjectType.Drawing);
            } else if (string.Equals(projectType, "Vector"))
            {
                projects = _allProjects.Where(p => p.ProjectType == ProjectType.Vector);
            }
            else
            {
                projects = new Project[0];
            }

            return projects;
        }
    }
}
