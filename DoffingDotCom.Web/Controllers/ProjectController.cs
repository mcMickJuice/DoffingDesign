using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            var projects = _projectService.GetActiveProjects();

            return View(projects);
        }

        public ActionResult IndexByType(string projectType)
        {
            var projects = _projectService.GetProjectsByType(projectType);

            if (!projects.Any())
            {
                return View("ProjectNotFound");
            }

            var vm = new ProjectListViewModel(projectType, projects);

            return View(vm);
        }

        public ActionResult Project(string projectId)
        {
            var project = _projectService.GetProjectByName(projectId);

            if (project == null)
            {
                RedirectToAction("ProjectNotFound",new {projectName = projectId});
            }
            return View(project);
        }

        public ActionResult ProjectNotFound(string projectName)
        {

            return View("ProjectNotFound",projectName);
        }
    }
}