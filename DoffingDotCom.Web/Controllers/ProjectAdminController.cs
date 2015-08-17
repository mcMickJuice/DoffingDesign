using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoffingDotCom.Web.Controllers
{
#warning TODO Add Security attribute here
    public class ProjectAdminController : Controller
    {
        // GET: ProjectAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}