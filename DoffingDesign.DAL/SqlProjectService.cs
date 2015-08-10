using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service;
using Project = DoffingDesign.Service.Models.Project;
using ProjectDb = DoffingDesign.DAL.EntityModels.Project;
using ProjectItem = DoffingDesign.Service.Models.ProjectItem;

namespace DoffingDesign.DAL
{
    public class SqlProjectService : IProjectService
    {
        private IDoffingDotComModel _context;

        public SqlProjectService(IDoffingDotComModel context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetActiveProjects()
        {
            var projects = _context.Set<ProjectDb>()
                .Where(p => p.IsActive)
                .ToList();

            var ps = projects.Select(p =>
            {
                var proj = new Project
                {
                    ProjectId = p.AppSlug,
                    ProjectItems = p.ProjectItems.Select(pi => new ProjectItem
                    {
                        AltText = pi.AltText,
                        ImageCaption = pi.ImageCaption,
                        ImageName = pi.ImageName,
                        ImageUrl = pi.ImageUrl,
                        IsThumb = pi.IsThumb
                    }),
                    ProjectMarkdown = p.ProjectMarkdown,
                    ProjectType = p.ProjectType,
                    SortOrder = p.SortOrder,
                    Title = p.Title,
                    ViewName = p.ProjectTemplate.TemplateName
                };

                var s6Info = p.ThirdPartyInfos.FirstOrDefault(t => t.ThirdPartySiteType == ThirdPartySiteType.Society6);

                if (s6Info == null) return proj;
                proj.Society6Id = s6Info.SiteId;
                proj.Society6Link = string.Format("http://www.society6.com/{0}", s6Info.SiteId);

                return proj;
            });

            return ps;
        }

        public Project GetProjectByName(string projectName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByType(string projectType)
        {
            var projects = GetActiveProjects();
            return projects;
//            throw new NotImplementedException();
        }
    }
}
