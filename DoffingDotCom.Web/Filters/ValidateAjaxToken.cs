using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace DoffingDotCom.Web.Filters
{
    public class ValidateAjaxTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string cookieToken = "";
            string formToken = "";

            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("RequestVerificationToken", out headers))
            {
                var tokens = headers.First().Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }

            }

            AntiForgery.Validate(cookieToken, formToken);
        }
    }
}