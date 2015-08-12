using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Models;
using Project = DoffingDesign.Service.Models.Project;
using ProjectDb = DoffingDesign.DAL.EntityModels.Project;
using ProjectItem = DoffingDesign.Service.Models.ProjectItem;
using LinqKit;

namespace DoffingDesign.DAL
{
    public class SqlProjectService : IProjectService
    {
        private IDoffingDotComModel _context;
        private readonly IProjectMapper _projectMapper;

        public SqlProjectService(IDoffingDotComModel context, IProjectMapper projectMapper)
        {
            _context = context;
            _projectMapper = projectMapper;
        }

        public IList<Project> GetActiveProjects()
        {
            var projects = _context.Set<ProjectDb>()
                .Where(p => p.IsActive)
                .ToList();

            var ps = projects.Select(_projectMapper.ToViewModel).ToList();

            return ps;
        }

        public Project GetProjectByName(string projectName)
        {
            var project = _context.Set<ProjectDb>()
                .AsExpandable()
                .FirstOrDefault(p => projectName.ToUpper() == p.AppSlug.ToUpper()); //TODO change this

            return _projectMapper.ToViewModel(project);
        }

        public IList<Project> GetProjectsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetProjectsByType(string projectType)
        {
            var projectTypeDict = new Dictionary<string,ProjectType>
            {
                {"Drawings",ProjectType.Drawing},
                {"Vector",ProjectType.Vector},
                {"Painting",ProjectType.Painting},
            };

            var type = projectTypeDict[projectType];

            var projects = _context.Set<ProjectDb>()
                    .Where(p => p.ProjectType == type)
                    .ToList()
                    .Select(_projectMapper.ToViewModel)
                    .ToList();

            return projects;
        }
    }
}
