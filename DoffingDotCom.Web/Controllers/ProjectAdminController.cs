using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DoffingDesign.Service.Models;

namespace DoffingDotCom.Web.Controllers
{
    //add security attribute
    public class ProjectAdminController : ApiController
    {
        public async Task<IEnumerable<Project>> Index()
        {
            throw new NotImplementedException();
        }

        public async Task<Project> Edit(string projectId)
        {
            throw new NotImplementedException();
            
        }

        public async Task<Project> Add()
        {
            throw new NotImplementedException();
            
        }

        public async Task<bool> Deactivate(string projectId)
        {
            throw new NotImplementedException();
            
        }
    }
}
