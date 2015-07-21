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
        IEnumerable<Project> GetActiveProjects();
        Project GetProjectByName(string projectName);
        IEnumerable<Project> GetProjectByTag(string tag);
        IEnumerable<Project> GetProjectsByType(string projectType);
    }
}
