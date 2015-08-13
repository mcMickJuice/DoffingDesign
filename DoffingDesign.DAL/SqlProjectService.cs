using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
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

        private readonly Expression<Func<ProjectDb,object>>[] _includes = 
        {
            p => p.ProjectTemplate,
            p => p.ProjectItems,
            p => p.ThirdPartyInfos
        };

        public SqlProjectService(IDoffingDotComModel context, IProjectMapper projectMapper)
        {
            _context = context;
            _projectMapper = projectMapper;
        }

        public IList<Project> GetActiveProjects()
        {
            var projects = getProjects(p => p.IsActive,
                _includes);

            var ps = projects.Select(_projectMapper.ToViewModel).ToList();

            return ps;
        }

        public Project GetProjectByName(string projectName)
        {
            var project = getFirstProject(p => projectName.ToUpper() == p.AppSlug.ToUpper(),
                _includes);

            return _projectMapper.ToViewModel(project);
        }

        public IList<Project> GetProjectsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetProjectsByType(string projectType)
        {
            var projectTypeDict = new Dictionary<string, ProjectType>
            {
                {"Drawings",ProjectType.Drawing},
                {"Vector",ProjectType.Vector},
                {"Painting",ProjectType.Painting},
            };

            var type = projectTypeDict[projectType];

            var projects = getProjects(p => p.ProjectType == type,
               _includes)
                .Select(_projectMapper.ToViewModel)
                .ToList();

            return projects;
        }

        private IList<ProjectDb> getProjects(Expression<Func<ProjectDb, bool>> predicate,
            params Expression<Func<ProjectDb, object>>[] includes)
        {
            var query = _context.Set<ProjectDb>().AsQueryable();

            //just like reduce in javascript!
            query = includes.Aggregate(query,(acc,i) => acc.Include(i));

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.AsExpandable().ToList();
        }

        private ProjectDb getFirstProject(Expression<Func<ProjectDb, bool>> predicate,
            params Expression<Func<ProjectDb, object>>[] includes)
        {
            var query = _context.Set<ProjectDb>().AsQueryable();

            query = includes.Aggregate(query, (acc,i) => acc.Include(i));
            ;

            return query.FirstOrDefault(predicate);
        }
    }
}
