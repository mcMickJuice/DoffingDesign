using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.Service.Models;

namespace DoffingDesign.Service
{
    public interface IProjectEnumService
    {
        Task<ProjectEnums> GetProjectEnums();
    }


}
