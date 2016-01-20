using System.Collections.Generic;
using DoffingDesign.Service.Models;
using ProjectVm = DoffingDesign.Service.Models.Project;

namespace DoffingDotCom.Web.Models.Project
{
    public class ProjectViewModel
    {
        public ProjectVm Project  { get; private set; }

        public string ProjectTypeName
        {
            get
            {
                var projectType = Project.ProjectType;
                return EnumToFriendlyProjectName[projectType];
            }
        }

        public string ProjectTypePath
        {
            get { return Project.ProjectType.ToString(); }
        }

        public ProjectViewModel(ProjectVm project)
        {
            Project = project;
        }

        private Dictionary<ProjectType, string> EnumToFriendlyProjectName = new Dictionary<ProjectType, string>
        {
            {ProjectType.FineArt, "Fine Art"},
            {ProjectType.Illustration, "Illustration"},
            {ProjectType.Pattern, "Patterns"},
        }; 
    }
}