namespace DoffingDesign.Service.Models
{
    public class ProjectTemplateInfo
    {
        public ProjectTemplateInfo(int id, string templateName)
        {
            Id = id;
            TemplateName = templateName;
        }

        public int Id { get; private set; }
        public string TemplateName { get; private set; }
    }
}