using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DoffingDesign.Service;

namespace DoffingDotCom.Web.Controllers
{
#warning    TODO add security attribute here
    [RoutePrefix("api/projectValues")]
    public class ProjectValuesApiController : ApiController
    {
        private readonly IProjectEnumService _enumService;

        public ProjectValuesApiController(IProjectEnumService enumService)
        {
            _enumService = enumService;
        }

        [HttpGet]
        [Route("")]
        public async Task<object> GetProjectFormValues()
        {
            var formValues = await _enumService.GetProjectEnums();

            return formValues;
        }
    }
}
