using Microsoft.AspNet.Mvc;
using System;

namespace Escalade.Web.Mvc.Attributes
{
    public class LayoutAttribute : ActionFilterAttribute
    {
        private readonly string layout;
        public LayoutAttribute(string layout)
        {
            this.layout = layout;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["layout"]
            }
        }
    }
}