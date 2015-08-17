using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DoffingDesign.Service;
using DoffingDesign.Service.Models;

namespace DoffingDotCom.Web.Controllers
{

#warning    TODO add security attribute here
    [RoutePrefix("api/projects")]
    public class ProjectAdminApiController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectAdminApiController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _projectService.GetActiveProjects();

            return projects;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Project> GetProjectById(string id)
        {
            var project = await _projectService.GetProjectByName(id);

            return project;
        }

        [HttpPost]
        [Route("")]
        public async Task<int> Add(ProjectEditInfo projectInfo)
        {
            //create project and return project id so that edit screen can take over
            //not ideal as it takes two trips but meh
            //TODO return project and have client handle this newly createed project
            var projectId = await _projectService.CreateProject(projectInfo);

            return projectId;

        }

        [HttpPut]
        [Route("")]
        public async Task<Project> Edit(Project project)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Deactivate(string id)
        {
            throw new NotImplementedException();

        }
    }
}
