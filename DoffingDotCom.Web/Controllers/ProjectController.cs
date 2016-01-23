using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
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
        private readonly IDiagnosticLogger _logger;

        public ProjectController(IProjectService projectService, IDiagnosticLogger logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var sw = new Stopwatch();
            var message = "ProjectController:Index";
            _logger.LogActivity(message);
            sw.Start();
            var projects = await _projectService.GetActiveProjects();
            sw.Stop();
            _logger.LogActivity(message,TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds));

            return View(projects);
        }

        public async Task<ActionResult> IndexByType(string projectType)
        {
            var sw = new Stopwatch();
            var message = "ProjectController:IndexByType";
            _logger.LogActivity(message);
            sw.Start();
            var projects = await _projectService.GetProjectsByType(projectType);
            sw.Stop();
            _logger.LogActivity(message, TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds));

            if (!projects.Any())
            {
                return View("ProjectNotFound");
            }

            var vm = new ProjectListViewModel(projectType, projects);

            return View(vm);
        }

        public async Task<ActionResult> Project(string projectId)
        {
            var sw = new Stopwatch();
            var message = "ProjectController:Project";
            _logger.LogActivity(message);
            sw.Start();
            var project = await _projectService.GetProjectByName(projectId);
            sw.Stop();
            _logger.LogActivity(message,TimeSpan.FromMilliseconds(sw.Elapsed.TotalMilliseconds));

            if (project == null)
            {
                return RedirectToAction("ProjectNotFound",new {projectName = projectId});
            }

            var vm = new ProjectViewModel(project);
            return View(vm);
        }

        public ActionResult ProjectNotFound(string projectName)
        {
            return View("ProjectNotFound", projectName);
        }
    }
}