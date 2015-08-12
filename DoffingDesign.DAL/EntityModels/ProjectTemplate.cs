using System.Collections.Generic;

namespace DoffingDesign.DAL.EntityModels
{
    public class ProjectTemplate
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}