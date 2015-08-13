using System.Linq;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service.Markdown;
using Project = DoffingDesign.Service.Models.Project;

namespace DoffingDesign.DAL.Mapping
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly IProjectItemMapper _itemMapper;
        private readonly IMarkdownService _markdownService;

        public ProjectMapper(IProjectItemMapper itemMapper, IMarkdownService markdownService)
        {
            _itemMapper = itemMapper;
            _markdownService = markdownService;
        }

        public Project ToViewModel(EntityModels.Project dbEntity)
        {
            var proj = new Project
            {
                ProjectId = dbEntity.AppSlug,
                ProjectItems = dbEntity.ProjectItems.Select(_itemMapper.ToViewModel),
                ProjectMarkdown = dbEntity.ProjectMarkdown,
                ProjectHtml = _markdownService.ConvertToHtml(dbEntity.ProjectMarkdown),
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

        public EntityModels.Project ToDbValue(Project viewModelEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}