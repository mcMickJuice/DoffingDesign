using System.Linq;
using DoffingDesign.DAL.EntityModels;
using Project = DoffingDesign.Service.Models.Project;
using ProjectDb = DoffingDesign.DAL.EntityModels.Project;
using ProjectItem = DoffingDesign.Service.Models.ProjectItem;
using ProjectItemDb = DoffingDesign.DAL.EntityModels.ProjectItem;

namespace DoffingDesign.DAL.Mapping
{
    public interface IDoffingDotComMapper<T,TDb>
    {
        T ToViewModel(TDb dbEntity);
        TDb ToDbValue(T viewModelEntity);
    }

    public interface IProjectMapper : IDoffingDotComMapper<Project, ProjectDb>
    {
        
    }

    public class ProjectMapper : IProjectMapper
    {
        private readonly IProjectItemMapper _itemMapper;

        public ProjectMapper(IProjectItemMapper itemMapper)
        {
            _itemMapper = itemMapper;
        }

        public Project ToViewModel(ProjectDb dbEntity)
        {
            var proj = new Project
            {
                ProjectId = dbEntity.AppSlug,
                ProjectItems = dbEntity.ProjectItems.Select(_itemMapper.ToViewModel),
                ProjectMarkdown = dbEntity.ProjectMarkdown,
                ProjectType = dbEntity.ProjectType,
                SortOrder = dbEntity.SortOrder,
                Title = dbEntity.Title,
                ViewName = dbEntity.ProjectTemplate.TemplateName
            };

            var s6Info = dbEntity.ThirdPartyInfos.FirstOrDefault(t => t.ThirdPartySiteType == ThirdPartySiteType.Society6);

            if (s6Info == null) return proj;
            proj.Society6Id = s6Info.SiteId;
            proj.Society6Link = string.Format("http://www.society6.com/{0}", s6Info.SiteId);

            return proj;
        }

        public ProjectDb ToDbValue(Project viewModelEntity)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IProjectItemMapper : IDoffingDotComMapper<ProjectItem, ProjectItemDb>
    {
        
    }

    public class ProjectItemMapper : IProjectItemMapper
    {
        public ProjectItem ToViewModel(ProjectItemDb dbEntity)
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

        public ProjectItemDb ToDbValue(ProjectItem viewModelEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
