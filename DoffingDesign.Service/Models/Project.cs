using System.Collections.Generic;

namespace DoffingDesign.Service.Models
{
    public class Project
    {
        public string ProjectId { get; set; }
        public ProjectType ProjectType { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
//        public string ProjectHtml { get; set; }

        public string ProjectMarkdown { get; set; }

        public IEnumerable<ProjectItem> ProjectItems { get; set; }
        public string Society6Id { get; set; }
        public string Society6Link { get; set; }
        private string _templateName;

        public string ViewName
        {
            get { return string.Format("_{0}", _templateName); }
            set { _templateName = value; }
        }
    }

    public class ProjectItem
    {
        public string ImageName { get; set; }
        public string ImageCaption { get; set; }
        public string AltText { get; set; }
        public bool IsThumb { get; set; }
        public string ImageUrl { get; set; } //Url, key for cloud service, etc.
    }
}