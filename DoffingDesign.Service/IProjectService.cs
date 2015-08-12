using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.Service.Models;

namespace DoffingDesign.Service
{
    public interface IProjectService
    {
        IList<Project> GetActiveProjects();
        Project GetProjectByName(string projectName);
        IList<Project> GetProjectsByTag(string tag);
        IList<Project> GetProjectsByType(string projectType);
    }
}
