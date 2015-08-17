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
        Task<List<Project>> GetActiveProjects();
        Task<Project> GetProjectByName(string projectName);
        Task<List<Project>> GetProjectsByTag(string tag);
        Task<List<Project>> GetProjectsByType(string projectType);
        Task<Project> UpdateProjectInfo(ProjectEditInfo project);
        Task<int> CreateProject(ProjectEditInfo projectInfo);
    }
}
