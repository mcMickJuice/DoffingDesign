using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DoffingDesign.Service;
using DoffingDotCom.Web.Models.Project;

namespace DoffingDotCom.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ActionResult> Index()
        {
            var projects = await _projectService.GetActiveProjects();

            return View(projects);
        }

        public async Task<ActionResult> IndexByType(string projectType)
        {
            var projects = await _projectService.GetProjectsByType(projectType);

            if (!projects.Any())
            {
                return View("ProjectNotFound");
            }

            var vm = new ProjectListViewModel(projectType, projects);

            return View(vm);
        }

        public async Task<ActionResult> Project(string projectId)
        {
            var project = await _projectService.GetProjectByName(projectId);

            if (project == null)
            {
                RedirectToAction("ProjectNotFound",new {projectName = projectId});
            }

            var vm = new ProjectViewModel(project);
            return View(vm);
        }

        public ActionResult ProjectNotFound(string projectName)
        {

            return View("ProjectNotFound",projectName);
        }
    }
}