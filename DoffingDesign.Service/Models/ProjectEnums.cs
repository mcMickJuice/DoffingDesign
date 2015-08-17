using System.Collections.Generic;

namespace DoffingDesign.Service.Models
{
    public class ProjectEnums
    {
        public ProjectEnums(IEnumerable<ProjectTemplateInfo> templateInfos
            , IEnumerable<ProjectTypeInfo> projectTypes )
        {
            Templates = templateInfos;
            ProjectTypes = projectTypes;
        }

        public IEnumerable<ProjectTemplateInfo> Templates { get; private set; }
        public IEnumerable<ProjectTypeInfo> ProjectTypes { get; private set; }
    }
}