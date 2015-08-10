namespace DoffingDesign.DAL.Models
{
    public class ProjectItem
    {
        public int Id{ get; set; } 
        public string ImageName { get; set; }
        public string ImageCaption { get; set; }
        public string AltText { get; set; }
        public bool IsThumb { get; set; }
        public string ImageUrl { get; set; }
    }
}