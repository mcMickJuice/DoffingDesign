using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using DoffingDotCom.Web.Services;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace DoffingDotCom.Web.Filters
{
    public class ValidateAjaxTokenAttribute : ActionFilterAttribute
    {
        public RequestForgeryService ForgeryService { get; set; }
        public DiagnosticLogger DiagnosticLogger { get; set; }

        public ValidateAjaxTokenAttribute()
        {
            ForgeryService = new RequestForgeryService();
            DiagnosticLogger = new DiagnosticLogger();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var isValid = ForgeryService.ValidateTokenHeaderValue(actionContext.Request.Headers);

            if (isValid) return;

            DiagnosticLogger.LogError("Unauthorized Access to ValidateAjaxToken");
            throw new InvalidOperationException("This is an unauthorized Action");
            
        }
    }
}