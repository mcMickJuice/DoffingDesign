using System.Collections.Generic;
using ProjectVm = DoffingDesign.Service.Models.Project;

namespace DoffingDotCom.Web.Models.Project
{
    public class ProjectListViewModel
    {
        public string ProjectType { get; private set; }
        public IEnumerable<ProjectVm> Projects { get; private set; }

        public ProjectListViewModel(string projectType, IEnumerable<ProjectVm> projects)
        {
            ProjectType = projectType;
            Projects = projects;
        }
    }
}