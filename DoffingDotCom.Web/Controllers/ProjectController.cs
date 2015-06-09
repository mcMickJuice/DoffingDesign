using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoffingDesign.Service;

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

        public ActionResult Project(string projectName)
        {
            var project = _projectService.GetProjectByName(projectName);

            if (project == null)
            {
                RedirectToAction("ProjectNotFound",new {projectName});
            }
            return View(project);
        }

        public ActionResult ProjectNotFound(string projectName)
        {

            return View("ProjectNotFound",projectName);
        }
    }
}