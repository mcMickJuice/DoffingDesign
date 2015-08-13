using DoffingDesign.Service.Models;

namespace DoffingDesign.DAL.Mapping
{
    public class ProjectItemMapper : IProjectItemMapper
    {
        public ProjectItem ToViewModel(EntityModels.ProjectItem dbEntity)
        {
            return new ProjectItem
            {
                AltText = dbEntity.AltText,
                ImageCaption = dbEntity.ImageCaption,
                ImageName = dbEntity.ImageName,
                ImageUrl = dbEntity.ImageUrl,
                IsThumb = dbEntity.IsThumb
            };
        }

        public EntityModels.ProjectItem ToDbValue(ProjectItem viewModelEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}