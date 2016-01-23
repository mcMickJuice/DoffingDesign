using System.Collections.Generic;
using ProjectVm = DoffingDesign.Service.Models.Project;

namespace DoffingDotCom.Web.Models.Project
{
    public class ProjectListViewModel:ProjectViewModelBase
    {
        public string ProjectType { get; private set; }
        public string ProjectPath { get; private set; }
        public IEnumerable<ProjectVm> Projects { get; private set; }

        public ProjectListViewModel(string projectType, IEnumerable<ProjectVm> projects)
        {
            ProjectType = GetFriendlyProjectType(projectType);
            ProjectPath = projectType;
            Projects = projects;
        }
    }
}