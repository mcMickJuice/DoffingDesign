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

    public interface IProjectItemMapper : IDoffingDotComMapper<ProjectItem, ProjectItemDb>
    {
        
    }
}
