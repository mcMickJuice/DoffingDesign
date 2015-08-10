using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service;
using DoffingDesign.Service.Models;

namespace DoffingDesign.DAL
{
    public class SqlProjectService : IProjectService
    {
        private IDoffingDotComModel _context;

        public SqlProjectService(IDoffingDotComModel context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetActiveProjects()
        {
            throw new NotImplementedException();
        }

        public Project GetProjectByName(string projectName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByType(string projectType)
        {
            throw new NotImplementedException();
        }
    }
}
