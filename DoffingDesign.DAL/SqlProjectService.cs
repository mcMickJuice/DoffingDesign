using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.DAL.Helpers;
using DoffingDesign.DAL.Mapping;
using DoffingDesign.Service;
using DoffingDesign.Service.Models;
using Project = DoffingDesign.Service.Models.Project;
using ProjectDb = DoffingDesign.DAL.EntityModels.Project;
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

        public async Task<List<Project>> GetActiveProjects()
        {
            var projects = await getProjects(p => p.IsActive,
                _includes);

            var ps = projects.Select(_projectMapper.ToViewModel).ToList();

            return ps;
        }

        public async Task<Project> GetProjectByName(string projectName)
        {
            var project = await getFirstProject(p => projectName.ToUpper() == p.AppSlug.ToUpper(),
                _includes);

            return _projectMapper.ToViewModel(project);
        }

        public Task<List<Project>> GetProjectsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetProjectsByType(string projectType)
        {
            var projectTypeDict = new Dictionary<string, ProjectType>
            {
                {"FineArt",ProjectType.FineArt},
                {"Illustration",ProjectType.Illustration},
                {"Pattern",ProjectType.Pattern},
            };

            var type = projectTypeDict[projectType];

            var projects = await getProjects(p => p.ProjectType == type,_includes);

            var mappedProjects = projects
                .Select(_projectMapper.ToViewModel)
                .ToList();

            return mappedProjects;
        }

        public async Task<Project> UpdateProjectInfo(ProjectEditInfo project)
        {
            var dbProject = await _context.Set<ProjectDb>()
                .FindAsync(project.Id);

            dbProject.ProjectMarkdown = project.ProjectMarkdown;
            dbProject.ProjectType = project.ProjectType;
            dbProject.SortOrder = project.SortOrder;
            dbProject.Title = project.Title;

            _context.SaveChanges();

            return _projectMapper.ToViewModel(dbProject);
        }

        public async Task<int> CreateProject(ProjectEditInfo projectInfo)
        {
            //NOT NECESSARY, UPDATE
            var template = await _context.Set<ProjectTemplate>().FindAsync(projectInfo.TemplateId);

            var dbProject = new ProjectDb
            {
                AppSlug = AppSlugTransformer.CreateSlug(projectInfo.Title),
                IsActive = true,
                Title = projectInfo.Title,
                ProjectMarkdown = projectInfo.ProjectMarkdown,
                ProjectType = projectInfo.ProjectType,
                SortOrder = projectInfo.SortOrder,
                ProjectTemplate = template
            };

            _context.Set<ProjectDb>()
                .Add(dbProject);

            await _context.SaveChangesAsync();

            return dbProject.Id;
        }

        private Task<List<ProjectDb>> getProjects(Expression<Func<ProjectDb, bool>> predicate,
            params Expression<Func<ProjectDb, object>>[] includes)
        {
            //use using statement here?
            var query = _context.Set<ProjectDb>().AsQueryable();

            //just like reduce in javascript!
            query = includes.Aggregate(query,(acc,i) => acc.Include(i));

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.AsExpandable().ToListAsync();

//            return query.AsExpandable().ToList();
        }

        private Task<ProjectDb> getFirstProject(Expression<Func<ProjectDb, bool>> predicate,
            params Expression<Func<ProjectDb, object>>[] includes)
        {
            var query = _context.Set<ProjectDb>().AsQueryable();

            query = includes.Aggregate(query, (acc,i) => acc.Include(i));
            ;

            return query.FirstOrDefaultAsync(predicate);
        }
    }
}
