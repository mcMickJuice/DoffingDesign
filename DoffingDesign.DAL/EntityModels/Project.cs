using System.Collections.Generic;
using DoffingDesign.DAL.Models;
using DoffingDesign.Service.Models;
using ProjectItem = DoffingDesign.DAL.Models.ProjectItem;

namespace DoffingDesign.DAL.EntityModels
{
    public class Project
    {
        public Project()
        {
            ProjectItems = new List<ProjectItem>();
            ThirdPartyInfos = new List<ThirdPartySiteInfo>();
        }

        public int Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public string ProjectMarkdown { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<ProjectItem> ProjectItems { get; set; }
        public IEnumerable<ThirdPartySiteInfo> ThirdPartyInfos { get; set; }
        public ProjectTemplate ProjectTemplate { get; set; }
    }
}
