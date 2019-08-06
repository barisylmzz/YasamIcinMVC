using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YasamIcin.UI.MVC.Tools
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectToRouteResult
                    (new RouteValueDictionary
                        (new { controller = "Error", action = "Index", ErrorText = filterContext.Exception.Message}));

        }
    }
}