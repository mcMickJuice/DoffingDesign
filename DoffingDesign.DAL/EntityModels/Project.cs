using System.Collections.Generic;
using DoffingDesign.Service.Models;

namespace DoffingDesign.DAL.Models
{
    public class Project
    {
        public string Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public string ProjectMarkdown { get; set; }

        public IEnumerable<ProjectItem> ProjectItems { get; set; }
        public ProjectTemplate ProjectTemplate { get; set; }
    }
}
