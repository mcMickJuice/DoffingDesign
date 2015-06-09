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
        private IEnumerable<Project> _allProjects = new List<Project>
        {
            new Project()
            {
                ProjectId = "project1",
                Title = "Project 1",
                ProjectHtml = "<h2>Project 1 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 1
            },
            new Project()
            {
                ProjectId = "project2",
                Title ="Project 2",
                ProjectHtml = "<h2>Project 2 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 2
            },
            new Project()
            {
                ProjectId = "project3",
                Title = "Project 3",
                ProjectHtml = "<h2>Project 3 Here</h2><p>I'm a paragraph!</p>",
                ProjectType = ProjectType.Drawing,
                SortOrder = 3
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
    }
}
