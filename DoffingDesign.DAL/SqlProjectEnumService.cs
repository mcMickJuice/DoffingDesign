using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.DAL.EntityModels;
using DoffingDesign.Service;
using DoffingDesign.Service.Models;

namespace DoffingDesign.DAL
{
    public class SqlProjectEnumService : IProjectEnumService
    {
        private readonly IDoffingDotComModel _context;

        public SqlProjectEnumService(IDoffingDotComModel context)
        {
            _context = context;
        }

        public async Task<ProjectEnums> GetProjectEnums()
        {
            var templates = (await _context.Set<ProjectTemplate>()
                .Where(t => t.IsAvailable)
                .ToListAsync());

            var templateInfos = templates.Select(t => new ProjectTemplateInfo(
                t.Id, 
                t.TemplateName));

            var enumInfos = Enum.GetValues(typeof (ProjectType))
                .OfType<ProjectType>()
                .Select(t => new ProjectTypeInfo
                {
                    Id = (int) t,
                    ProjectTypeName = t.ToString()
                });
                    

            return new ProjectEnums(templateInfos, enumInfos);
        }
    }
}
