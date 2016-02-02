using System.Threading.Tasks;
using DoffingDesign.Service.Models;

namespace DoffingDesign.Service
{
    public interface IProjectEnumService
    {
        Task<ProjectEnums> GetProjectEnums();
    }


}
