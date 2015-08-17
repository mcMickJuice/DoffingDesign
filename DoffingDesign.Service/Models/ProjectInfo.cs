using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoffingDesign.Service.Models
{
    public class ProjectEditInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ProjectType ProjectType { get; set; }
        public int SortOrder { get; set; }
        public int TemplateId { get; set; }
        public string ProjectMarkdown { get; set; }
    }
}
