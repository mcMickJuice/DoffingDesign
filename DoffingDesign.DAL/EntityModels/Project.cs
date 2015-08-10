using System.Collections.Generic;
using DoffingDesign.Service.Models;
using ProjectItem = DoffingDesign.DAL.EntityModels.ProjectItem;

namespace DoffingDesign.DAL.EntityModels
{
    public class Project
    {
        public int Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Title { get; set; }
        public string AppSlug { get; set; }
        public int SortOrder { get; set; }
        public string ProjectMarkdown { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ProjectItem> ProjectItems { get; set; }
        public virtual ICollection<ThirdPartySiteInfo> ThirdPartyInfos { get; set; }
        public virtual ProjectTemplate ProjectTemplate { get; set; }
    }
}
