using System.Collections.Generic;
using System.Linq;
using DoffingDesign.Service.Models;

namespace DoffingDotCom.Web.Models.Project
{
    public abstract class ProjectViewModelBase
    {

        private readonly Dictionary<ProjectType, string> _enumToFriendlyProjectNameMapping = new Dictionary<ProjectType, string>
        {
            {ProjectType.FineArt, "Fine Art"},
            {ProjectType.Illustration, "Illustration"},
            {ProjectType.Pattern, "Patterns"},
        };

        protected string GetFriendlyProjectType(ProjectType type)
        {
            return _enumToFriendlyProjectNameMapping[type];
        }

        protected string GetFriendlyProjectType(string projectType)
        {
            return _enumToFriendlyProjectNameMapping.FirstOrDefault(m => m.Key.ToString() == projectType)
                .Value;
        }
    }
}